

using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Infrastructure.Messaging;
using neredekalCaseStudy.Persistance;
using RabbitMQ.Client;
using System.Reflection;

namespace neredekalCaseStudy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            var rabbitMqHostName = builder.Configuration["RabbitMQ:HostName"];
            builder.Services.AddScoped<IRabbitMQService>(sp =>
                new RabbitMQService(rabbitMqHostName));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
