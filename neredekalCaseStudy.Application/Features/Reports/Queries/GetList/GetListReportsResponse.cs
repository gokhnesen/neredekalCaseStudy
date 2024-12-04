using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetList
{
    public class GetListReportsResponse
    {
     
        public Guid ReportId { get; set; }
        public DateTime RequestDate { get; set; }
        public string ReportStatus { get; set; }
        public object Content { get; set; }
        public string Location { get; set; }
        public int TotalHotels { get; set; }
        public int TotalPhoneNumbers { get; set; }

    }
}
