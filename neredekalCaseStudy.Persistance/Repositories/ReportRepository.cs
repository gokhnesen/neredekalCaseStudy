using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;

namespace neredekalCaseStudy.Persistance.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetHotelCountByLocationAsync(string location)
        {
            var hotelCount = await _context.Hotels
                .Where(hotel => hotel.ContactInformations
                    .Any(ci => ci.Content.Contains(location))) 
                .CountAsync();

            return hotelCount;
        }

        public async Task<int> GetPhoneCountByLocationAsync(string location)
        {
            int totalPhoneNumbers = 0;

            var phoneNumbers = await _context.ContactInformations
                .Where(ci => ci.Location == location && ci.Type == ContactType.PhoneNumber)
                .ToListAsync();

            totalPhoneNumbers = phoneNumbers.Count;

            return totalPhoneNumbers;
        }
    }
}
