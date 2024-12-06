using AutoMapper;
using neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create;
using neredekalCaseStudy.Application.Features.HotelContacts.Commands.Delete;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.HotelContacts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ContactInformation, CreateHotelContactCommand>().ReverseMap();
            CreateMap<ContactInformation, CreateHotelContactResponse>().ReverseMap();

            CreateMap<ContactInformation, DeleteHotelContactCommand>().ReverseMap();
            CreateMap<ContactInformation, DeleteHotelContactResponse>().ReverseMap();

        }
    }
}
