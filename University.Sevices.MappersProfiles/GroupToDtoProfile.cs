using AutoMapper;
using University.Domain.Core;
using University.Services.Dto;

namespace University.Services.MappersProfiles
{
    public class GroupToDtoProfile : Profile
    {
        public GroupToDtoProfile()
        {
            CreateMap<Group, GroupDto>()
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest =>
                        dest.CourseId,
                    opt => opt.MapFrom(scr => scr.CourseId))
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(scr => scr.Name))
                .ReverseMap()
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}