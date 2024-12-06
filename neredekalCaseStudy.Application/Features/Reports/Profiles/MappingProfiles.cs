using AutoMapper;
using neredekalCaseStudy.Application.Features.Reports.Commands.Create;
using neredekalCaseStudy.Application.Features.Reports.Queries.GetById;
using neredekalCaseStudy.Application.Features.Reports.Queries.GetList;
using neredekalCaseStudy.Domain.Entities;

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
    .ForMember(dest => dest.ReportStatus, opt => opt.MapFrom(src => src.Status.ToString()))
     .ForMember(dest => dest.RequestDate,
                    opt => opt.MapFrom(src => src.RequestedDate.ToString("dd/MM/yyyy HH:mm")));
            CreateMap<Report, GetListReportsResponse>()
                .ForMember(dest => dest.RequestDate,
                    opt => opt.MapFrom(src => src.RequestedDate.ToString("dd/MM/yyyy HH:mm")));
        }

    }
}
