using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetHotelManager
{
    public class GetHotelManagersQuery : IRequest<List<GetHotelManagersQueryResponse>>
    {
        public Guid Id { get; set; }

        public class GetHotelManagersQueryHandler : IRequestHandler<GetHotelManagersQuery, List<GetHotelManagersQueryResponse>>
        {
            private readonly IHotelRepository _hotelRepository;
            private readonly IMapper _mapper;

            public GetHotelManagersQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
            {
                _hotelRepository = hotelRepository;
                _mapper = mapper;
            }

            public async Task<List<GetHotelManagersQueryResponse>> Handle(GetHotelManagersQuery request, CancellationToken cancellationToken)
            {
                List<Hotel> hotelManagers = await _hotelRepository.GetAllAsync();

                List<GetHotelManagersQueryResponse> response = _mapper.Map<List<GetHotelManagersQueryResponse>>(hotelManagers);

                return response;
            }
        }
    }
}
