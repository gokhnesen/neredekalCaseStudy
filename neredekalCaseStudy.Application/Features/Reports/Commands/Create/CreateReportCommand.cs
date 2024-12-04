using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Commands.Create
{
    public class CreateReportCommand() : IRequest<CreateReportResponse>
    {
        public string Location { get; set; }

    }
}
