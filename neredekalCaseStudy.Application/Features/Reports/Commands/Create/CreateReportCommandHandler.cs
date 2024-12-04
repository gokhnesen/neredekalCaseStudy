using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Commands.Create
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportResponse>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IMapper _mapper;

        public CreateReportCommandHandler(IReportRepository reportRepository, IHotelRepository hotelRepository,
            IContactInformationRepository contactInformationRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _hotelRepository = hotelRepository;
            _contactInformationRepository = contactInformationRepository;
            _mapper = mapper;
        }

        public async Task<CreateReportResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report
            {
                Id = Guid.NewGuid(),
                Location = request.Location,
                RequestedDate = DateTime.UtcNow,
                Status = ReportStatus.InProgress,
            };

            var hotels = await _hotelRepository.GetHotelsByLocationAsync(request.Location);
            var totalHotels = hotels.Count();

            int totalPhoneNumbers = 0;

            foreach (var hotel in hotels)
            {
                if (hotel.ContactInformations != null && hotel.ContactInformations.Any())
                {
                    var locationContact = hotel.ContactInformations
                        .FirstOrDefault(c => c.Type == ContactType.Location && c.Content.Contains(request.Location));

                    if (locationContact != null)
                    {
                        var phoneNumbers = hotel.ContactInformations
                            .Where(c => c.Type == ContactType.PhoneNumber && !string.IsNullOrWhiteSpace(c.Content)) 
                            .ToList();

                        totalPhoneNumbers += phoneNumbers.Count;
                    }
                }
            }

            report.TotalHotels = totalHotels;
            report.TotalPhoneNumbers = totalPhoneNumbers;

            await _reportRepository.AddAsync(report);

            var response = _mapper.Map<CreateReportResponse>(report);
            return response;
        }


    }
}
