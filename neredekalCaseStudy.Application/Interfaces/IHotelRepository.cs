using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> GetHotelsByLocationAsync(string location);
        Task<int> GetHotelCountByLocationAsync(string location);
        Task<Hotel?> GetByIdWithDetailsAsync(Guid id);
    }
}
