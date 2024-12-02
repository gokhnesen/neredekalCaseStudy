using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create
{
    public class CreateHotelContactCommandHandler : IRequestHandler<CreateHotelContactCommand,CreateHotelContactResponse>
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IMapper _mapper;

        public CreateHotelContactCommandHandler(IContactInformationRepository contactInformationRepository, IMapper mapper)
        {
            _contactInformationRepository = contactInformationRepository;
            _mapper = mapper;
        }

        public async Task<CreateHotelContactResponse>? Handle(CreateHotelContactCommand request,CancellationToken cancellationToken)
        {
            ContactInformation contactInformation = _mapper.Map<ContactInformation>(request);
            contactInformation.Id = Guid.NewGuid();
            await _contactInformationRepository.AddAsync(contactInformation);

            CreateHotelContactResponse createHotelContactResponse = _mapper.Map<CreateHotelContactResponse>(contactInformation);
            return createHotelContactResponse;
        }


    }
}
