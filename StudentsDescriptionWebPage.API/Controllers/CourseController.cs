﻿using Microsoft.AspNetCore.Mvc;
using Repository.Models.DataTransferObject.Course;
using Service.Interfaces;

namespace StudentsDescriptionWebPage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    //todo for Igor: Create HttpGet method in the controller and methods in 
    //CourseService and CourseRepository. Besides it create dto models for every method listed above
    //Dto models based on the domain Course model.

    //todo Igor: implement GetCourseById()
    [HttpGet("courses")]
    public async Task<IActionResult> GetAllCourses()
    {
        var result = await _courseService.GetAllCourses();

        return Ok(result);
    }

    [HttpPost("course")]
    public async Task<IActionResult> CreateProfile([FromQuery]CourseDto courseDto)
    {
        await _courseService.CreateCourse(courseDto);

        return Ok();
    }

    //todo for Igor: Create HttpPut method in the controller and methods in 
    //CourseService and CourseRepository. Besides it create dto models for every method listed above
    //Dto models based on the domain Course model.

    //todo for Igor: Create HttpDelete method in the controller and methods in 
    //CourseService and CourseRepository. Besides it create dto models for every method listed above
    //Dto models based on the domain Course model.
}
