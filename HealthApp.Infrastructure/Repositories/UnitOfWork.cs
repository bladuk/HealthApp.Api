using HealthApp.Infrastructure.Interfaces;
using HealthApp.Infrastructure.Persistence;

namespace HealthApp.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private HealthAppDbContext _dbContext;
    private AssessmentRepository _assessmentRepository;

    public UnitOfWork(HealthAppDbContext dbContext)
    {
        _dbContext = dbContext;
        _assessmentRepository = new AssessmentRepository(_dbContext);
    }

    public IAssessmentRepository Assessments => _assessmentRepository;

    public Task<int> SaveChangesAsync(CancellationToken token = default) => _dbContext.SaveChangesAsync(token);

    public void Dispose() => _dbContext.Dispose();
}