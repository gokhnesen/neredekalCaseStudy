using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location);
        Task<Hotel?> GetByIdWithDetailsAsync(Guid id);
    }
}
