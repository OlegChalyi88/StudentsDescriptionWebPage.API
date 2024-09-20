using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;

namespace Service.Interfaces;

public interface ICourseService
{
    Task<List<CourseDto>> GetAllCourses();
    Task CreateCourse(CourseDto courseDto);
    Task<CourseDto> GetCourseById(Guid courseId);
    Task<CurrentCourse?> DeleteCourseById(Guid courseId);
}
