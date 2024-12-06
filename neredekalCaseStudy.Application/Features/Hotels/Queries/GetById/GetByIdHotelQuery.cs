using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetById
{
    public class GetByIdHotelQuery : IRequest<GetByIdHotelQueryResponse>
    {
        public Guid Id { get; set; }



    }
}
