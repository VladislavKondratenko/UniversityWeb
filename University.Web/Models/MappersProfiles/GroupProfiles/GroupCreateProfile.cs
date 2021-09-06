using AutoMapper;
using University.Services.Dto;
using University.Web.Models.ViewModels.GroupsViewModels;

namespace University.Web.Models.MappersProfiles.GroupProfiles
{
    public class GroupCreateProfile : Profile
    {
        public GroupCreateProfile()
        {
            CreateMap<GroupDto, GroupCreateViewModel>()
                .ForMember(dest =>
                        dest.CourseId,
                    opt => opt.MapFrom(scr => scr.CourseId))
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(scr => scr.Name))
                .ReverseMap();
        }
    }
}