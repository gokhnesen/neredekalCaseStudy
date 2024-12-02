using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create;
using neredekalCaseStudy.Application.Features.HotelContacts.Commands.Delete;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Delete;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetById;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetHotelManager;

namespace neredekalCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : BaseController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            GetByIdHotelQuery getByIdHotelQuery = new() { Id = id };
            GetByIdHotelQueryResponse response = await Mediator.Send(getByIdHotelQuery);
            return Ok(response);
        }

        [HttpGet("hotel-manager-list")]
        public async Task<IActionResult> GetList()
        {
            var query = new GetHotelManagersQuery();
            List<GetHotelManagersQueryResponse> response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand createHotelCommand)
        {
            CreateHotelResponse response = await Mediator.Send(createHotelCommand);
            return Ok(response);
        }

        [HttpPost("add-contact")]
        public async Task<IActionResult> CreateHotelContactInfo([FromBody] CreateHotelContactCommand createHotelContactCommand)
        {
            CreateHotelContactResponse response = await Mediator.Send(createHotelContactCommand);
            return Ok(response);
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteHotelResponse response = await Mediator.Send(new DeleteHotelCommand { Id = id });
            return Ok(response);
        }
        
        [HttpDelete("delete-contact{id}")]
        
        public async Task<IActionResult> DeleteContactInfo([FromRoute] Guid id)
        {
            DeleteHotelContactResponse response = await Mediator.Send(new DeleteHotelContactCommand { Id = id });
            return Ok(response);
        }
    }
}
