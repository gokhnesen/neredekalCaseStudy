using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Infrastructure.MessageQueue.Consumer;
using neredekalCaseStudy.Infrastructure.Messaging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace neredekalCaseStudy.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqHostName = configuration["RabbitMQ:HostName"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()  
                .WriteTo.Console()  
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,  
                    IndexFormat = "logs-{0:yyyy.MM.dd}",  
                    MinimumLogEventLevel = LogEventLevel.Information  
                })
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog()
            );

            services.AddScoped<IRabbitMQService>(sp =>
                new RabbitMQService(rabbitMqHostName));

            services.AddHostedService<ReportConsumerService>();
        }
    }
}
