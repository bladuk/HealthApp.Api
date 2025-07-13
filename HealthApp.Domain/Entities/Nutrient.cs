using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class Nutrient
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal Min { get; set; }

    public decimal Max { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<NutrientIntake> NutrientIntakes { get; set; } = new List<NutrientIntake>();
}
