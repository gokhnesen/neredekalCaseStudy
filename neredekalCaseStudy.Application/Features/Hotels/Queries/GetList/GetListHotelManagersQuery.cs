using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetHotelManager
{
    public class GetListHotelManagersQuery : IRequest<List<GetListHotelManagersResponse>>
    {
        public Guid Id { get; set; }


    }
}
