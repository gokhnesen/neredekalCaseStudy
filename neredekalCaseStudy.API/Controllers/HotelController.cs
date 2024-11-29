using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace neredekalCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }   
    }
}
