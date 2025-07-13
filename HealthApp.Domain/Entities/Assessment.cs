using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class Assessment
{
    public Guid Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? RecommendedSetId { get; set; }

    public virtual ICollection<NutrientIntake> NutrientIntakes { get; set; } = new List<NutrientIntake>();

    public virtual Set? RecommendedSet { get; set; }

    public virtual User User { get; set; } = null!;
}
