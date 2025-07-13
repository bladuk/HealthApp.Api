namespace HealthApp.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAssessmentRepository Assessments { get; }
    Task<int> SaveChangesAsync(CancellationToken token = default);
}