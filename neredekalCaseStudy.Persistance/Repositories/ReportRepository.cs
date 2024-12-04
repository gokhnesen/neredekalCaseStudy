using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using neredekalCaseStudy.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Persistence.Repositories
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
                    .Any(ci => ci.Type == ContactType.Location && ci.Content.Contains(location))) 
                .CountAsync();

            return hotelCount;
        }

        public async Task<int> GetPhoneCountByLocationAsync(string location)
        {
            var phoneCount = await _context.ContactInformations
                .Where(ci => ci.Type == ContactType.PhoneNumber)
                .Join(_context.Hotels,
                    ci => ci.HotelId,
                    hotel => hotel.Id,
                    (ci, hotel) => new { ci, hotel })  
                .Where(x => x.hotel.ContactInformations
                    .Any(hotelCi => hotelCi.Type == ContactType.Location && hotelCi.Content.Contains(location))) 
                .CountAsync();

            return phoneCount;
        }

    }
}
