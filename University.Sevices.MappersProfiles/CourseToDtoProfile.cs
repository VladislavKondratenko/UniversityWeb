using AutoMapper;
using University.Domain.Core;
using University.Services.Dto;

namespace University.Services.MappersProfiles
{
    public class CourseToDtoProfile : Profile
    {
        public CourseToDtoProfile()
        {
            CreateMap<Course, CourseDto>()
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