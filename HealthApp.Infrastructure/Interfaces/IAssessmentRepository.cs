using HealthApp.Domain.Entities;

namespace HealthApp.Infrastructure.Interfaces;

public interface IAssessmentRepository : IRepository<Assessment, Guid>
{
    Task<Assessment?> GetLatestAsync(int userId, CancellationToken ct = default);
}