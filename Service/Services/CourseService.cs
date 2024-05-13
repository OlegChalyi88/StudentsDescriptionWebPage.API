using AutoMapper;
using Repository.Interfaces;
using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;
using Service.Interfaces;

namespace Service.Repositories;

public class CourseService : ICourseService
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public CourseService(IMapper mapper, ICourseRepository courseRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task CreateCourse(CourseDto courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);

        await _courseRepository.AddCourse(course);
    }
}
