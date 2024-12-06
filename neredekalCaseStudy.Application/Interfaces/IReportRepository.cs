using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        Task<int> GetHotelCountByLocationAsync(string location);

        Task<int> GetPhoneCountByLocationAsync(string location);
    }
}
