using System;
using System.Collections.Generic;

namespace HealthApp.Domain.Entities;

public partial class SetAssessment
{
    public Guid Id { get; set; }

    public Guid AssessmentId { get; set; }

    public Guid SetId { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Set Set { get; set; } = null!;
}
