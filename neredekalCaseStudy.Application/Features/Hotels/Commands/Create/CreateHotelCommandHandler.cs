using MediatR;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Create
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand,CreateHotelResponse>
    {
        private readonly AppDbContext _context;

        public CreateHotelCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateHotelResponse> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = new Hotel
            {
                Id = Guid.NewGuid(),
                CompanyName = request.CompanyName,
                ManagerFirstName = request.ManagerFirstName,
                ManagerLastName = request.ManagerLastName,
                ContactInformations = request.ContactInformations.Select(i => new ContactInformation
                {
                    Id = Guid.NewGuid(),
                    InfoType = i.InfoType,
                    InfoContent = i.InfoContent,
                }).ToList()
            };

            _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateHotelResponse
            {
                Id = hotel.Id
            };
        }
    }
}
