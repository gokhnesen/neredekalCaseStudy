using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Interfaces
{
    public interface IContactInformationRepository : IGenericRepository<ContactInformation>
    {
        Task<IEnumerable<ContactInformation>> GetPhoneNumbersByLocationAsync(string location);


    }
}
