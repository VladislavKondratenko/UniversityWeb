using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.StudentViewModels;

namespace University.Web.Models.MappersProfiles.StudentProfiles
{
    public class StudentCreateProfile : Profile
    {
        public StudentCreateProfile()
        {
            CreateMap<StudentDto, StudentCreateViewModel>()
                .ForMember(dest =>
                        dest.GroupId,
                    opt => opt.MapFrom(scr => scr.GroupId))
                .ForMember(dest =>
                        dest.FirstName,
                    opt => opt.MapFrom(scr => scr.FirstName))
                .ForMember(dest =>
                        dest.LastName,
                    opt => opt.MapFrom(scr => scr.LastName))
                .ForMember(dest =>
                        dest.CourseId,
                    opt => opt.MapFrom(scr => scr.CourseId))
                .ReverseMap();
        }
    }
}