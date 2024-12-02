using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Commands.Delete
{
    public class DeleteHotelCommand : IRequest<DeleteHotelResponse>
    {
        public Guid Id { get; set; }

    }
}
