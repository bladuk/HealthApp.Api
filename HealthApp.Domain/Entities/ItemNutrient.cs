using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class ItemNutrient
{
    public Guid Id { get; set; }

    public Guid ItemId { get; set; }

    public Guid NutrientId { get; set; }

    public decimal Amount { get; set; }

    public virtual SetItem Item { get; set; } = null!;

    public virtual Nutrient Nutrient { get; set; } = null!;
}
