using Repository.Models.DataTransferObject.Course;

namespace Service.Interfaces;

public interface ICourseService
{
    Task<List<CourseDto>> GetAllCourses();
    Task CreateCourse(CourseDto courseDto);
    Task<CourseDto> GetCourseById(Guid courseId);
}
