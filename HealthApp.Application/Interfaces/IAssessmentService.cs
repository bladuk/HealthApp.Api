using HealthApp.Application.DTO;

namespace HealthApp.Application.Interfaces;

public interface IAssessmentService
{
    Task<AssessmentReportDto?> GetLatestReportAsync(int userId, CancellationToken token);
}