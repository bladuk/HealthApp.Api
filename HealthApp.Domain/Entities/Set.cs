using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class Set
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<SetAssessment> SetAssessments { get; set; } = new List<SetAssessment>();

    public virtual ICollection<SetItem> SetItems { get; set; } = new List<SetItem>();
}
