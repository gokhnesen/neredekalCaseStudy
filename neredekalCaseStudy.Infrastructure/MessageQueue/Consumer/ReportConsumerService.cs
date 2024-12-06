
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using neredekalCaseStudy.Application.Features.Reports.Commands.Create;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Infrastructure.MessageQueue.Consumer
{
    public class ReportConsumerService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string _queueName = "reportQueue";

        public ReportConsumerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _scopeFactory.CreateScope();

            var rabbitmqService = scope.ServiceProvider.GetRequiredService<IRabbitMQService>();

            rabbitmqService.ConsumeMessages<CreateReportResponse>(_queueName, report =>
            {
                GenerateReport(report.Id);
            });

            return Task.CompletedTask;
        }

        private async void GenerateReport(Guid reportId)
        {

            var scope = _scopeFactory.CreateScope();

            var reportRepository = scope.ServiceProvider.GetRequiredService<IReportRepository>();
            var hotelRepository = scope.ServiceProvider.GetRequiredService<IHotelRepository>();


            var report = await reportRepository.GetByIdAsync(reportId);

            var hotels = await hotelRepository.GetHotelsByLocationAsync(report.Location);
            var totalHotels = hotels.Count();
            //_logger.LogInformation("Found {TotalHotels} hotels for location: {Location}", totalHotels, report.Location);

            int totalPhoneNumbers = 0;

            foreach (var hotel in hotels)
            {
                if (hotel.ContactInformations != null && hotel.ContactInformations.Any())
                {
                    var locationContact = hotel.ContactInformations
                        .FirstOrDefault(c => c.Location.Contains(report.Location, StringComparison.OrdinalIgnoreCase));

                    if (locationContact != null)
                    {

                        var phoneNumbers = hotel.ContactInformations
                            .Where(c => c.Type == ContactType.PhoneNumber && !string.IsNullOrWhiteSpace(c.Content))
                            .ToList();

                        totalPhoneNumbers += phoneNumbers.Count;
                        //_logger.LogInformation("Hotel {HotelId} has {PhoneNumbersCount} phone numbers", hotel.Id, phoneNumbers.Count);
                    }
                }
            }


            report.TotalHotels = totalHotels;
            report.TotalPhoneNumbers = totalPhoneNumbers;
            report.Status = ReportStatus.Completed;

            //_logger.LogInformation("Saving report to database for location: {Location}", report.Location);
            await reportRepository.UpdateAsync(report);

            //_logger.LogInformation("Report successfully created for location: {Location}", report.Location);
        }
    }
}
