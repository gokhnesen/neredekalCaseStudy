using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Queries
{
    public class GetByIdReportDetailResponse
    {
        public Guid ReportId { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public int HotelCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
