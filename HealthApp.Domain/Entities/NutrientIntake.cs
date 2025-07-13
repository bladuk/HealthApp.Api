using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class NutrientIntake
{
    public Guid Id { get; set; }

    public Guid AssessmentId { get; set; }

    public Guid NutrientId { get; set; }

    public decimal Amount { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Nutrient Nutrient { get; set; } = null!;
}
