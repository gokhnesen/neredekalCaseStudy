using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }

        public ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
