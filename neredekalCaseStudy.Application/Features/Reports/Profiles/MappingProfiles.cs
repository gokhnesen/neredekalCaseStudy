using AutoMapper;
using neredekalCaseStudy.Application.Features.Hotels.Queries.GetById;
using neredekalCaseStudy.Application.Features.Reports.Commands.Create;
using neredekalCaseStudy.Application.Features.Reports.Queries.GetById;
using neredekalCaseStudy.Application.Features.Reports.Queries.GetList;
using neredekalCaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neredekalCaseStudy.Application.Features.Reports.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Report, CreateReportCommand>().ReverseMap();
            CreateMap<Report, CreateReportResponse>().ReverseMap();



            CreateMap<Report, GetByIdReportDetailResponse>()
    .ForMember(dest => dest.TotalHotels, opt => opt.MapFrom(src => src.TotalHotels))
    .ForMember(dest => dest.TotalPhoneNumbers, opt => opt.MapFrom(src => src.TotalPhoneNumbers))
    .ForMember(dest => dest.ReportStatus, opt => opt.MapFrom(src => src.Status.ToString())); // Eğer Status enum ise
            CreateMap<Report,GetListReportsResponse>().ReverseMap();
        }

    }
}
