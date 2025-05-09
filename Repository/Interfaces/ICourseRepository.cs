﻿using Repository.Models.DataTransferObject.Course;
using Repository.Models.Domain;

namespace Repository.Interfaces;

public interface ICourseRepository
{
    Task<List<Course>> RetrieveAllCourses();
    Task AddCourse(Course course);
}
