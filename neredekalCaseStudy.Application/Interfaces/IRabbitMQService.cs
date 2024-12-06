namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IRabbitMQService
    {
        void SendMessage(object message, string queueName);
        void ConsumeMessages<T>(string queueName , Action<T> onMessageReceived);
    }
}
