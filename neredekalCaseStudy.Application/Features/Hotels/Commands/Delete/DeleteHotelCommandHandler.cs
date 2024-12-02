using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Delete
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand,DeleteHotelResponse>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public DeleteHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<DeleteHotelResponse> Handle(DeleteHotelCommand request,CancellationToken cancellationToken)
        {
            Hotel? hotel = await _hotelRepository.GetByIdAsync(request.Id);
            hotel = _mapper.Map(request,hotel);

            await _hotelRepository.DeleteAsync(hotel);

            DeleteHotelResponse response = _mapper.Map<DeleteHotelResponse>(hotel);
            return response;

        }
    }
}
