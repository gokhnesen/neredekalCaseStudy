using MediatR;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create
{
    public class CreateHotelContactCommand : IRequest<CreateHotelContactResponse>
    {
        public Guid HotelId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
    }
}
