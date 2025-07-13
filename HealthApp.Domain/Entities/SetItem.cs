using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class SetItem
{
    public Guid Id { get; set; }

    public Guid SetId { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string ShopUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ItemNutrient> ItemNutrients { get; set; } = new List<ItemNutrient>();

    public virtual Set Set { get; set; } = null!;
}
