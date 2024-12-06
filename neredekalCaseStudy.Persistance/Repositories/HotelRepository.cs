using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;

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
            //var asd = from a in _context.Hotels
            //          join b in _context.ContactInformations on a.Id equals b.HotelId
            //          where 

            return await _context.Hotels.Include(x => x.ContactInformations)
                .Where(h => h.ContactInformations.Any(c => EF.Functions.Like(c.Location,$"%{location}"))) 
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
