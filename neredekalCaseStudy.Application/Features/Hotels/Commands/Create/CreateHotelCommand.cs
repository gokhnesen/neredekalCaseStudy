using MediatR;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Create
{
    public class CreateHotelCommand : IRequest<CreateHotelResponse>
    {
        public string CompanyName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public List<ContactInformationDto> ContactInformations { get; set; }

    }

    public class ContactInformationDto
    {
        public string InfoType { get; set; }
        public string InfoContent { get; set; }
    }
}
