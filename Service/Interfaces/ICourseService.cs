using Repository.Models.DataTransferObject.Course;

namespace Service.Interfaces;

public interface ICourseService
{
    Task CreateCourse(CourseDto courseDto);
}
