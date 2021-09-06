using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.CoursesViewModels;

namespace University.Web.Models.MappersProfiles.CourseProfiles
{
    public class CourseCreateProfile : Profile
    {
        public CourseCreateProfile()
        {
            CreateMap<CourseDto, CourseCreateViewModel>()
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(scr => scr.Name))
                .ForMember(dest =>
                        dest.Description,
                    opt => opt.MapFrom(scr => scr.Description))
                .ReverseMap();
        }
    }
}