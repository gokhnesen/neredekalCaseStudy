using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Persistance.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location)
        {
            return await FindyAsync(h =>
                h.ContactInformations.Any(c =>
                    c.Type == ContactType.Location && c.Content == location)
            );
        }

        public async Task<int> GetHotelCountByLocationAsync(string location)
        {
            return (await GetHotelsByLocationAsync(location)).Count();
        }
    }
}
