using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetList
{
    public class GetListReportsQuery : IRequest<List<GetListReportsResponse>>
    {


    }
}
