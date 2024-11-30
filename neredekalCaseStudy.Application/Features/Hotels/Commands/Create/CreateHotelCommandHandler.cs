using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Create
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand,CreateHotelResponse>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository,IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<CreateHotelResponse> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel hotel = _mapper.Map<Hotel>(request);
            hotel.Id = Guid.NewGuid();
            hotel.ManagerFirstName = request.ManagerFirstName;
            hotel.ManagerLastName = request.ManagerLastName;
            hotel.CompanyName = request.CompanyName;
            await _hotelRepository.AddAsync(hotel);

            CreateHotelResponse createHotelResponse = _mapper.Map<CreateHotelResponse>(hotel);
            return createHotelResponse;
        }
    }
}
