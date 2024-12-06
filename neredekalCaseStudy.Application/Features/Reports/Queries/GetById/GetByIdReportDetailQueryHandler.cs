using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Queries.GetById
{
    public class GetByIdReportDetailQueryHandler : IRequestHandler<GetByIdReportDetailQuery, GetByIdReportDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;

        public GetByIdReportDetailQueryHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<GetByIdReportDetailResponse> Handle(GetByIdReportDetailQuery request, CancellationToken cancellationToken)
        {
            Report? report = await _reportRepository.GetByIdAsync(request.Id);

            if (report == null)
            {
                throw new Exception("Rapor bulunamadı.");
            }

            report.Status = ReportStatus.Completed;

            var response = _mapper.Map<GetByIdReportDetailResponse>(report);


            return response;
        }
    }
}
