using HealthApp.Domain.Entities;
using HealthApp.Infrastructure.Interfaces;
using HealthApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthApp.Infrastructure.Repositories;

public sealed class AssessmentRepository(HealthAppDbContext dbContext) : IAssessmentRepository
{
    public async ValueTask<Assessment?> GetByIdAsync(Guid id, CancellationToken token = default)
        => await dbContext.Assessments
            .Include(a => a.NutrientIntakes).ThenInclude(i => i.Nutrient)
            .Include(a => a.RecommendedSet).ThenInclude(s => s.SetItems)
            .FirstOrDefaultAsync(a => a.Id == id, token);
    
    public async Task<Assessment?> GetLatestAsync(int userId, CancellationToken ct = default)
        => await dbContext.Assessments
            .Include(a => a.NutrientIntakes).ThenInclude(i => i.Nutrient)
            .Include(a => a.RecommendedSet).ThenInclude(s => s.SetItems)
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.CreatedAt)
            .FirstOrDefaultAsync(ct);
    
    public void Add(Assessment entity) => dbContext.Assessments.Add(entity);

    public void Update(Assessment entity) => dbContext.Assessments.Update(entity);

    public void Remove(Assessment entity) => dbContext.Assessments.Remove(entity);
}