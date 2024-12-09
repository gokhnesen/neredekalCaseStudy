﻿using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetHotelManager;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetList
{
    public class GetHotelManagersQueryHandler : IRequestHandler<GetListHotelManagersQuery, List<GetListHotelManagersResponse>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelManagersQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListHotelManagersResponse>> Handle(GetListHotelManagersQuery request, CancellationToken cancellationToken)
        {
            List<Hotel> hotelManagers = await _hotelRepository.GetAllAsync();

            List<GetListHotelManagersResponse> response = _mapper.Map<List<GetListHotelManagersResponse>>(hotelManagers);

            return response;
        }
    }
}
