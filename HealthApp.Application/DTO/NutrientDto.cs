using HealthApp.Application.Enums;

namespace HealthApp.Application.DTO;

public record NutrientDto(Guid Id, string Name, string Unit,
    decimal Amount, decimal Min, decimal Max,
    NutrientStatus Status);
    
public record SetDto(Guid Id, decimal Price, ICollection<SetItemDto> Items);

public record SetItemDto(Guid Id, string Name, string ImageUrl, string ShopUrl);

public record AssessmentReportDto(
    DateTime CreatedAt,
    IReadOnlyList<NutrientDto> CurrentIntake,
    IReadOnlyList<NutrientDto> IntakeWithSet,
    SetDto? Set
);