using MediatR;

namespace neredekalCaseStudy.Application.Features.Reports.Commands.Create
{
    public class CreateReportCommand() : IRequest<CreateReportResponse>
    {
        public string Location { get; set; }

    }
}
