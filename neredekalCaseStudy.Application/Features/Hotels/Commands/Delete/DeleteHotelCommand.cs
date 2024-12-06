using MediatR;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Delete
{
    public class DeleteHotelCommand : IRequest<DeleteHotelResponse>
    {
        public Guid Id { get; set; }

    }
}
