using Microsoft.EntityFrameworkCore;
using Repository.AdditionalHelper;
using Repository.Data;
using Repository.Interfaces;
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
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Course> RetrieveCourseById(Guid courseId)
    {
        var retrievedCourse = await _appDbContext.Courses.Where(c => c.Id.Equals(courseId)).FirstOrDefaultAsync();

        if (retrievedCourse == null)
        {
            throw new Exception(string.Format(Constants.NotFoundEntity, courseId));
        }
        return retrievedCourse;
    }

    public async Task RemoveCourseById(Guid courseId)
    {
        var retrievedCourse = await _appDbContext.Courses.Where(c => c.Id.Equals(courseId)).FirstOrDefaultAsync();

        if (retrievedCourse == null)
        {
            throw new Exception(string.Format(Constants.NotFoundEntity, courseId));
        }

        _appDbContext.Courses.Remove(retrievedCourse);
        _appDbContext.SaveChanges();
    }
}
