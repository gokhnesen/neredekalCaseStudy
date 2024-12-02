using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create
{
    public class CreateHotelContactResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public Guid HotelId { get; set; }
    }
}
