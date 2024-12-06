using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using Serilog;

namespace neredekalCaseStudy.Application.Features.Reports.Commands.Create
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportResponse>
    {

        //private readonly ILogger<CreateReportCommandHandler> _logger;
        private readonly IReportRepository _reportRepository;
        private readonly IRabbitMQService _rabbitMQService;

        public CreateReportCommandHandler(IRabbitMQService rabbitMQService, IReportRepository reportRepository)
        {
            //_logger = logger;
            _rabbitMQService = rabbitMQService;
            _reportRepository = reportRepository;
        }

        public async Task<CreateReportResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Starting to process report creation for location: {Location}", request.Location);

            var report = new Report
            {
                Id = Guid.NewGuid(),
                Location = request.Location,
                RequestedDate = DateTime.UtcNow,
                Status = ReportStatus.InProgress,
            };

            await _reportRepository.AddAsync(report);

            _rabbitMQService.SendMessage(new { report.Id } , "reportQueue");

            return new CreateReportResponse { Id = report.Id, Status = report.Status.ToString() };
        }
    }
}
