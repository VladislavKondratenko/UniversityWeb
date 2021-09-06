using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.GroupsViewModels;

namespace University.Web.Models.MappersProfiles.GroupProfiles
{
    public class GroupEditProfile : Profile
    {
        public GroupEditProfile()
        {
            CreateMap<GroupDto, GroupEditViewModel>()
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest =>
                        dest.CourseId,
                    opt => opt.MapFrom(scr => scr.CourseId))
                .ForMember(dest =>
                        dest.CourseName,
                    opt => opt.MapFrom(scr => scr.CourseName))
                .ForMember(dest =>
                        dest.ListOfCoursesNames,
                    opt => opt.MapFrom(scr => scr.ListOfCoursesNames))
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(scr => scr.Name))
                .ReverseMap();
        }
    }
}