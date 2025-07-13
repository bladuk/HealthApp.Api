using HealthApp.Application.DTO;
using HealthApp.Application.Enums;
using HealthApp.Application.Interfaces;
using HealthApp.Domain.Entities;
using HealthApp.Infrastructure.Interfaces;

namespace HealthApp.Application.Services;

public class AssessmentService(IUnitOfWork unitOfWork) : IAssessmentService
{
    public async Task<AssessmentReportDto?> GetLatestReportAsync(int userId, CancellationToken token)
    {
        var assessment = await unitOfWork.Assessments.GetLatestAsync(userId, token);

        if (assessment == null)
            return null;
        
        var current  = assessment.NutrientIntakes.Select(NutrientToDto).ToList();
        var withSet = CalculateIntakeWithSet(assessment.RecommendedSet, current);

        return new AssessmentReportDto(
            assessment.CreatedAt,
            current,
            withSet,
            SetToDto(assessment.RecommendedSet));
    }
    
    private static NutrientDto NutrientToDto(NutrientIntake intake) => new(
        intake.Nutrient.Id,
        intake.Nutrient.Name,
        intake.Nutrient.Unit,
        intake.Amount,
        intake.Nutrient.Min,
        intake.Nutrient.Max,
        GetStatus(intake.Amount, intake.Nutrient.Min, intake.Nutrient.Max));
    
    private static SetDto? SetToDto(Set? set) =>
         set == null ? null : new SetDto(set.Id, set.Price, set.SetItems.Select(SetItemToDto).ToList());
    
    private static SetItemDto SetItemToDto(SetItem item) =>
        new(item.Id, item.Name, item.ImageUrl, item.ShopUrl);
    
    private static NutrientStatus GetStatus(decimal amount, decimal min, decimal max) => amount switch
    {
        _ when amount < min => NutrientStatus.Deficit,
        _ when amount < (min + max) / 2 => NutrientStatus.Reduced,
        _ => NutrientStatus.Sufficient
    };
    
    private static IReadOnlyList<NutrientDto> CalculateIntakeWithSet(Set? set, IReadOnlyCollection<NutrientDto> current)
    {
        if (set is null)
            return current.ToList();
        
        var additions = set.SetItems.SelectMany(item => item.ItemNutrients)
            .GroupBy(itemNutrient => itemNutrient.Nutrient.Id)
            .ToDictionary(g => g.Key, g => g.Sum(itemNutrient => itemNutrient.Amount));
        
        var merged = new Dictionary<Guid, NutrientDto>();
        
        foreach (var dto in current)
            merged[dto.Id] = dto;
        
        foreach (var (id, addAmount) in additions)
        {
            if (merged.TryGetValue(id, out var exist))
            {
                var total = exist.Amount + addAmount;
                
                merged[id] = exist with
                {
                    Amount = total,
                    Status = GetStatus(total, exist.Min, exist.Max)
                };
            }
            else
            {
                var sample = set.SetItems.SelectMany(i => i.ItemNutrients).First(x => x.Nutrient.Id == id)
                    .Nutrient;
                
                merged[id] = new NutrientDto(
                    sample.Id,
                    sample.Name,
                    sample.Unit,
                    addAmount,
                    sample.Min,
                    sample.Max,
                    GetStatus(addAmount, sample.Min, sample.Max));
            }
        }
        
        return merged.Values.ToList();
    }
}