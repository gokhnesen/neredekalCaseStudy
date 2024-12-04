using neredekalCaseStudy.Application.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace neredekalCaseStudy.Infrastructure.Messaging
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly string _hostName;

        public RabbitMQService(string hostName)
        {
            _hostName = hostName ?? throw new ArgumentNullException(nameof(hostName));
        }

        public void SendMessage(object message, string queueName)
        {
            var factory = new ConnectionFactory { HostName = _hostName };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body);
        }
    }
}
