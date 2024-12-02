using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using neredekalCaseStudy.Persistance.Context;
using neredekalCaseStudy.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Persistence.Repositories
{
    public class ContactInformationRepository : GenericRepository<ContactInformation>, IContactInformationRepository
    {
        public ContactInformationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
