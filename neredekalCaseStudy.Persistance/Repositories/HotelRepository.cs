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

        private readonly AppDbContext _context;
        public HotelRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location)
        {
            return await _context.Hotels
                .Where(h => h.ContactInformations.Any(c => c.Type == ContactType.Location && c.Content == location))
                .ToListAsync();
        }

        public async Task<int> GetHotelCountByLocationAsync(string location)
        {
            return (await GetHotelsByLocationAsync(location)).Count();
        }

        public async Task<Hotel?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.Set<Hotel>()
                .Include(h => h.ContactInformations)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

    }
}
