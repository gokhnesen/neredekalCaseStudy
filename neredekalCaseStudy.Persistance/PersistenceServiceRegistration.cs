﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Persistance.Context;
using neredekalCaseStudy.Persistance.Repositories;
using neredekalCaseStudy.Persistence.Repositories;

namespace neredekalCaseStudy.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IContactInformationRepository, ContactInformationRepository>();

            return services;
        }
    }
}
