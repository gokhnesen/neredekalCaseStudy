using MediatR;
using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetById
{
    public class GetByIdHotelQuery: IRequest<GetByIdHotelQueryResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdHotelQueryHandler:IRequestHandler<GetByIdHotelQuery,GetByIdHotelQueryResponse>
        {
            private readonly AppDbContext _context;

            public GetByIdHotelQueryHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<GetByIdHotelQueryResponse> Handle(GetByIdHotelQuery request,CancellationToken cancellationToken)
            {
                var hotel = await _context.Hotels
                    .Include(h => h.ContactInformations)
                    .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);

                if(hotel == null)
                {
                    throw new DirectoryNotFoundException($"Hotel with Id {request.Id} not found");
                }

                return new GetByIdHotelQueryResponse
                {
                    CompanyName = hotel.CompanyName,
                    ManagerFirstName = hotel.ManagerFirstName,
                    ManagerLastName = hotel.ManagerLastName,
                    ContactInformations = hotel.ContactInformations.Select(i => new ContactInformationDto
                    {
                        InfoContent = i.InfoContent,
                        InfoType = i.InfoType,
                    }).ToList()

                };
            }
        }

    }
}
