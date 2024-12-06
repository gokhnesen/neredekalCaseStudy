using Microsoft.EntityFrameworkCore;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using neredekalCaseStudy.Persistance.Repositories;

namespace neredekalCaseStudy.Persistence.Repositories
{
    public class ContactInformationRepository : GenericRepository<ContactInformation>, IContactInformationRepository
    {
        public ContactInformationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
