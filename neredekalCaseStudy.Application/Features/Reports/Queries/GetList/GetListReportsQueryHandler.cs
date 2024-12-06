using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetList
{
    public class GetListReportsQueryHandler : IRequestHandler<GetListReportsQuery, List<GetListReportsResponse>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public GetListReportsQueryHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListReportsResponse>> Handle(GetListReportsQuery request, CancellationToken cancellationToken)
        {
            List<Report> reports = await _reportRepository.GetAllAsync();

            List<GetListReportsResponse> response = _mapper.Map<List<GetListReportsResponse>>(reports);

            return response;
        }
    }
}
