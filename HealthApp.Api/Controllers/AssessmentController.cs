using HealthApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssessmentController(IAssessmentService assessmentService) : ControllerBase
{
    [HttpGet]
    [Route("{userId}/latest")]
    public async Task<IActionResult> GetLatest([FromRoute] int userId, CancellationToken token)
    {
        var assessment = await assessmentService.GetLatestReportAsync(userId, token);
        
        if (assessment == null)
            return NotFound("Assessment not found");

        return Ok(assessment);
    }
}