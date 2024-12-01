using neredekalCaseStudy.Application.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace HotelGuide.Infrastructure.MessageQueue
{

    public class RabbitMQPublisher : IMessageQueuePublisher
    {
        private readonly IConnection _connection;

        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }

        public void Publish(string queueName, string message)
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }
}
