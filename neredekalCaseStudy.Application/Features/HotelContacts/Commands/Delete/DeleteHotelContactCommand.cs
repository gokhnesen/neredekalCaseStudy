using MediatR;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Delete
{
    public class DeleteHotelContactCommand : IRequest<DeleteHotelContactResponse>
    {
        public Guid Id { get; set; }
    }
}
