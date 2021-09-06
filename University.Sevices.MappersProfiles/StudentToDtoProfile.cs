using AutoMapper;
using University.Domain.Core;
using University.Services.Dto;

namespace University.Services.MappersProfiles
{
    public class StudentToDtoProfile : Profile
    {
        public StudentToDtoProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest =>
                        dest.Id,
                    opt => opt.MapFrom(scr => scr.Id))
                .ForMember(dest =>
                        dest.FirstName,
                    opt => opt.MapFrom(scr => scr.FirstName))
                .ForMember(dest =>
                        dest.LastName,
                    opt => opt.MapFrom(scr => scr.LastName))
                .ForMember(dest =>
                        dest.GroupId,
                    opt => opt.MapFrom(scr => scr.GroupId))
                .ReverseMap()
                .ForAllOtherMembers(o => o.Ignore());
        }
    }
}