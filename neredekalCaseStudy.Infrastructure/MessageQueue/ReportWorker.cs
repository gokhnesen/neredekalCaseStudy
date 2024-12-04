using neredekalCaseStudy.Application.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Text;
using neredekalCaseStudy.Domain.Entities;
using System.Threading.Tasks;

public class ReportWorker
{
    private readonly IReportRepository _reportRepository;

    public ReportWorker(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public void Start()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "report_queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonConvert.DeserializeObject<dynamic>(Encoding.UTF8.GetString(body));

            Guid reportId = message.ReportId;
            string location = message.Location;

            try
            {
                var hotelCount = await _reportRepository.GetHotelCountByLocationAsync(location);
                var phoneCount = await _reportRepository.GetPhoneCountByLocationAsync(location);

                var report = await _reportRepository.GetByIdAsync(reportId);
                report.Status = ReportStatus.Completed;
                report.TotalHotels = hotelCount;
                report.TotalPhoneNumbers = phoneCount;

                await _reportRepository.UpdateAsync(report);

                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error processing message: {ex.Message}");


            }
        };

        channel.BasicConsume(queue: "report_queue", autoAck: false, consumer: consumer);
    }
}
