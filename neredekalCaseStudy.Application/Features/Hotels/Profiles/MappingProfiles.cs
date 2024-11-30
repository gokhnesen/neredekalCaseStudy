using AutoMapper;
using neredekalCaseStudy.Application.Features.Hotels.Commands.Create;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetById;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Hotels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Hotel,CreateHotelCommand>().ReverseMap();
            CreateMap<Hotel, CreateHotelResponse>().ReverseMap();


            CreateMap<Hotel,GetByIdHotelQueryResponse>().ReverseMap();
        }
    }
}
