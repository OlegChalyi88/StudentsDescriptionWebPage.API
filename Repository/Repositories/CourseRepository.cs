using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;
using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;

namespace Repository.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _appDbContext;

    public CourseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Course>> RetrieveAllCourses()
    {
        List<Course> courses = await _appDbContext.Courses.ToListAsync();

        return courses;
    }

    public async Task AddCourse(Course course)
    {
        await _appDbContext.Courses.AddAsync(course);
        await _appDbContext.SaveChangesAsync(); ;
    }
}
