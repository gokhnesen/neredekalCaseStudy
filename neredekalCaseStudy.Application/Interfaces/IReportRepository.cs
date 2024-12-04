using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IReportRepository :IGenericRepository<Report>
    {
        Task<int> GetHotelCountByLocationAsync(string location);

        Task<int> GetPhoneCountByLocationAsync(string location);
    }
}
