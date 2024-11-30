using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetById
{
    public class GetByIdHotelQueryResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
    }
}
