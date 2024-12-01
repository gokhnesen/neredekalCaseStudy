using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Commands.Create
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand,CreateReportResponse>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;
        private readonly IMessageQueuePublisher _queuePublisher;

        public CreateReportCommandHandler(IReportRepository reportRepository, IMapper mapper,IMessageQueuePublisher queuePublisher)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _queuePublisher = queuePublisher;
        }

        public async Task<CreateReportResponse>? Handle(CreateReportCommand request,CancellationToken cancellationToken)
        {
            Report report = _mapper.Map<Report>(request);
            report.Id = Guid.NewGuid();
            report.RequestedAt = DateTime.UtcNow;
            report.Status = ReportStatus.InProgress;
            report.Location = request.Location;

            await _reportRepository.AddAsync(report);
            _queuePublisher.Publish("report_queue", report.Id.ToString());


            CreateReportResponse createReportResponse = _mapper.Map<CreateReportResponse>(report);
            return createReportResponse;
        }
    }
}
