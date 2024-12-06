using MediatR;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Create
{
    public class CreateHotelCommand : IRequest<CreateHotelResponse>
    {
        public string CompanyName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }

    }
}
