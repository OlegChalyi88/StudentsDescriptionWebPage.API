using AutoMapper;
using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;

namespace Service.Mapping;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, Course>()
            .ForMember(dest => dest.CurrentCourse, opt => opt.MapFrom(src => src.CurrentCourse.ToString()))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => "Oleh"))
            .ReverseMap();

        CreateMap<Course, CourseDto>()
            .ConstructUsing(src => new CourseDto(src.GroupName, src.TitleOfCourse, src.TeacherName, src.StartDateOfCourse, src.CurrentCourse));
    }
}
