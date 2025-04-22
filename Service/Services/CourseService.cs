using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;
using Service.Interfaces;

namespace Service.Repositories;

public class CourseService : ICourseService
{
    private readonly ILogger<CourseService> _logger;
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public CourseService(ILogger<CourseService> logger, IMapper mapper, ICourseRepository courseRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task<List<CourseDto>> GetAllCourses()
    {
        List<Course> courses = await _courseRepository.RetrieveAllCourses();
        List<CourseDto> coursesDto = _mapper.Map<List<CourseDto>>(courses);

        return coursesDto;
    }

    public async Task CreateCourse(CourseDto courseDto)
    {
        var course = _mapper.Map<Course>(courseDto);

        await _courseRepository.AddCourse(course);
    }

    public async Task<CourseDto> GetCourseById(Guid courseId)
    {
        var foundCourse = await _courseRepository.RetrieveCourseById(courseId);

        var courseDto = _mapper.Map<CourseDto>(foundCourse);
        return courseDto;
    }

    public async Task<CurrentCourse?> DeleteCourseById(Guid courseId)
    {
        var foundCourse = await _courseRepository.RetrieveCourseById(courseId);
        if (foundCourse == null)
        {
            return null;
        }

        await _courseRepository.RemoveCourseById(courseId);
        return foundCourse.CurrentCourse;
    }

    public async Task<CourseDto> EditCourse(CourseDto courseDto)
    {
        var mappedCourse = _mapper.Map<Course>(courseDto);
        var updatedCourse = await _courseRepository.UpdateCourse(mappedCourse);

        var updatedCourseDto = _mapper.Map<CourseDto>(updatedCourse);
        return updatedCourseDto;
    }
}
