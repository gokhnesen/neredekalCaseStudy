using AutoMapper;
using ClosedXML.Excel;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetById
{
    public class GetByIdReportDetailQuery : IRequest<GetByIdReportDetailResponse>
    {
        public Guid Id { get; set; }


    }
}
