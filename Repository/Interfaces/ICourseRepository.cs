using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;

namespace Repository.Interfaces;

public interface ICourseRepository
{
    Task AddCourse(Course course);
}
