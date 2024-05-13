using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("course")]
    public async Task<IActionResult> CreateProfile([FromQuery]CourseDto courseDto)
    {
        await _courseService.CreateCourse(courseDto);

        return Ok();
    }

}
