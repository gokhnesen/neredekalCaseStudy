using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Delete
{
    public class DeleteHotelContactCommand : IRequest<DeleteHotelContactResponse>
    {
        public Guid Id { get; set; }
    }
}
