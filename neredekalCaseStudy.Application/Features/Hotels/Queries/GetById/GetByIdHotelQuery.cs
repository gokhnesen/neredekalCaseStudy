using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
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
            private readonly IMapper _mapper;
            private readonly IHotelRepository _hotelRepository;

            public GetByIdHotelQueryHandler(IMapper mapper, IHotelRepository hotelRepository)
            {
                _mapper = mapper;
                _hotelRepository = hotelRepository;
            }

            public async Task<GetByIdHotelQueryResponse> Handle(GetByIdHotelQuery request,CancellationToken cancellationToken)
            {
                Hotel? hotel = await _hotelRepository.GetByIdAsync(request.Id);
                GetByIdHotelQueryResponse response = _mapper.Map<GetByIdHotelQueryResponse>(hotel);
                return response;
            }
        }

    }
}
