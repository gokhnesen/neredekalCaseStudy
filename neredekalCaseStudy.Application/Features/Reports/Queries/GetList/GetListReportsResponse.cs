using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetList
{
    public class GetListReportsResponse
    {

        public Guid Id { get; set; }
        public string RequestDate { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

    }
}
