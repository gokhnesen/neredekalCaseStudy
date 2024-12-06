using AutoMapper;
using MediatR;
using neredekalCaseStudy.Application.Interfaces;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Commands.Delete
{
    public class DeleteHotelContactCommandHandler : IRequestHandler<DeleteHotelContactCommand, DeleteHotelContactResponse>
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IMapper _mapper;

        public DeleteHotelContactCommandHandler(IContactInformationRepository contactInformationRepository, IMapper mapper)
        {
            _contactInformationRepository = contactInformationRepository;
            _mapper = mapper;
        }

        public async Task<DeleteHotelContactResponse> Handle(DeleteHotelContactCommand request, CancellationToken cancellationToken)
        {
            ContactInformation contactInformation = await _contactInformationRepository.GetByIdAsync(request.Id);
            contactInformation = _mapper.Map(request, contactInformation);

            await _contactInformationRepository.DeleteAsync(contactInformation);

            DeleteHotelContactResponse response = _mapper.Map<DeleteHotelContactResponse>(contactInformation);
            return response;
        }
    }
}
