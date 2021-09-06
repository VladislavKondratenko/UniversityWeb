using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.CoursesViewModels;

namespace University.Web.Models.MappersProfiles.CourseProfiles
{
    public class CourseEditProfile : Profile
    {
        public CourseEditProfile()
        {
            CreateMap<CourseDto, CourseEditViewModel>()
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
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