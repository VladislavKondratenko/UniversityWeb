using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.CoursesViewModels;

namespace University.Web.Models.MappersProfiles.CourseProfiles
{
    public class CourseDeleteProfile : Profile
    {
        public CourseDeleteProfile()
        {
            CreateMap<CourseDto, CourseDeleteViewModel>()
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(scr => scr.Name))
                .ForMember(dest =>
                        dest.NumberGroups,
                    opt => opt.MapFrom(scr => scr.NumberGroups))
                .ReverseMap();
        }
    }
}