using MediatR;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create
{
    public class CreateHotelContactCommand : IRequest<CreateHotelContactResponse>
    {
        public Guid HotelId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
    }
}
