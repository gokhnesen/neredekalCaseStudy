namespace neredekalCaseStudy.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime RequestedDate { get; set; }
        public ReportStatus Status { get; set; }
        public string Location { get; set; }
        public int TotalHotels { get; set; }
        public int TotalPhoneNumbers { get; set; }

    }
    public enum ReportStatus
    {
        InProgress,
        Completed
    }
}
