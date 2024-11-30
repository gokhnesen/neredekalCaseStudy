using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetById;

namespace neredekalCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand createHotelCommand)
        {
            CreateHotelResponse response = await Mediator.Send(createHotelCommand);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            GetByIdHotelQuery getByIdHotelQuery = new() { Id = id };
            GetByIdHotelQueryResponse response = await Mediator.Send(getByIdHotelQuery);
            return Ok(response);
        }
    }
}
