using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neredekalCaseStudy.Application.Features.Reports.Commands.Create;
using neredekalCaseStudy.Application.Features.Reports.Queries;

namespace neredekalCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportCommand createReportCommand)
        {
            CreateReportResponse response = await Mediator.Send(createReportCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportDetails(Guid id)
        {
            GetByIdReportDetailQuery getByIdReportDetailQuery = new() { Id = id };
            GetByIdReportDetailResponse response = await Mediator.Send(getByIdReportDetailQuery);
            return Ok(response);
        }
    }
}
