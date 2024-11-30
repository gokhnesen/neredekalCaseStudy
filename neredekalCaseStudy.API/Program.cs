

using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application;
using neredekalCaseStudy.Persistance;
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
