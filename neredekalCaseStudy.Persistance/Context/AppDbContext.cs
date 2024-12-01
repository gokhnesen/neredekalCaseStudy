using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
