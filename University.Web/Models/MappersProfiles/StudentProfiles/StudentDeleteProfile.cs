using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.StudentViewModels;

namespace University.Web.Models.MappersProfiles.StudentProfiles
{
    public class StudentDeleteProfile : Profile
    {
        public StudentDeleteProfile()
        {
            CreateMap<StudentDto, StudentDeleteViewModel>()
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest =>
                        dest.GroupId,
                    opt => opt.MapFrom(scr => scr.GroupId))
                .ForMember(dest =>
                        dest.CourseId,
                    opt => opt.MapFrom(scr => scr.CourseId))
                .ForMember(dest =>
                        dest.GroupName,
                    opt => opt.MapFrom(scr => scr.GroupName))
                .ForMember(dest =>
                        dest.FirstName,
                    opt => opt.MapFrom(scr => scr.FirstName))
                .ForMember(dest =>
                        dest.LastName,
                    opt => opt.MapFrom(scr => scr.LastName))
                .ReverseMap();
        }
    }
}