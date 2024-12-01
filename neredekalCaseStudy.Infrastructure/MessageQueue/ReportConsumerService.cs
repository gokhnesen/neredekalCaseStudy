using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace HotelGuide.Infrastructure.MessageQueue
{
    public class ReportConsumerService : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IServiceProvider _serviceProvider;

        public ReportConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: "report_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var reportId = Guid.Parse(Encoding.UTF8.GetString(body));

                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var report = await context.Reports.FindAsync(reportId);
                if (report == null) return;

                // Raporu işleme (basit bir örnek)
                var hotels = context.Hotels.Where(h => h.ContactInformations.Any(c => c.Type == ContactType.Location && c.Content == report.Location)).ToList();
                report.HotelCount = hotels.Count;
                report.PhoneNumberCount = hotels.Sum(h => h.ContactInformations.Count(c => c.Type == ContactType.PhoneNumber));
                report.Status = ReportStatus.Completed;

                await context.SaveChangesAsync();
            };

            channel.BasicConsume(queue: "report_queue", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
