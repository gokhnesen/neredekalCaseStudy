namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetById
{
    public class GetByIdReportDetailResponse
    {
        public Guid Id { get; set; }
        public string RequestDate { get; set; }
        public string ReportStatus { get; set; }
        public string Location { get; set; }
        public int TotalHotels { get; set; }
        public int TotalPhoneNumbers { get; set; }
    }
}

