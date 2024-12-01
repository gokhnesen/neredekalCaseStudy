using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Reports.Commands.Create
{
    public class CreateReportResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}