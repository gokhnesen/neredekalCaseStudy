using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetById;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetHotelManager;
using neredekalCaseStudy.Application.Features.Reports.Commands.Create;
using neredekalCaseStudy.Application.Features.Reports.Queries;
using neredekalCaseStudy.Application.Features.Reports.Queries.GetById;
using neredekalCaseStudy.Application.Features.Reports.Queries.GetList;
using neredekalCaseStudy.Application.Interfaces;
using System.Runtime.CompilerServices;

namespace neredekalCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetReports()
        {
            var query = new GetListReportsQuery();
            List<GetListReportsResponse> response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetReportDetails(Guid id)
        {
            var query = new GetByIdReportDetailQuery { Id = id };
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
