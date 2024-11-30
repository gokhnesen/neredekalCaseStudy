using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public string LocationInfo { get; set; }
        public int RegisteredHotelCount { get; set; }
        public int RegisteredPhoneNumberCount { get; set; }
    }
    public enum ReportStatus
    {
        InProgress,
        Completed
    }
}
