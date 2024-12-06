using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create
{
    public class CreateHotelContactCommandHandler : IRequestHandler<CreateHotelContactCommand, CreateHotelContactResponse>
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IMapper _mapper;

        public CreateHotelContactCommandHandler(IContactInformationRepository contactInformationRepository, IMapper mapper)
        {
            _contactInformationRepository = contactInformationRepository;
            _mapper = mapper;
        }

        public async Task<CreateHotelContactResponse>? Handle(CreateHotelContactCommand request, CancellationToken cancellationToken)
        {
            ContactInformation contactInformation = _mapper.Map<ContactInformation>(request);
            await _contactInformationRepository.AddAsync(contactInformation);

            CreateHotelContactResponse createHotelContactResponse = _mapper.Map<CreateHotelContactResponse>(contactInformation);
            return createHotelContactResponse;
        }


    }
}
