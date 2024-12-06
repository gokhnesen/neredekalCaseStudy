using AutoMapper;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Delete;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetById;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetHotelManager;
using neredekalCaseStudy.Domain.Entities;

namespace neredekalCaseStudy.Application.Features.Hotels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Hotel, CreateHotelCommand>().ReverseMap();
            CreateMap<Hotel, CreateHotelResponse>().ReverseMap();

            CreateMap<Hotel, DeleteHotelCommand>().ReverseMap();
            CreateMap<Hotel, DeleteHotelResponse>().ReverseMap();



            CreateMap<Hotel, GetListHotelManagersResponse>().ReverseMap();
            CreateMap<Hotel, GetByIdHotelQueryResponse>().ReverseMap();
        }
    }
}
