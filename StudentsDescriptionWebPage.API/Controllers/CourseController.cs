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

    [HttpGet("getcourse/{id:guid}")]
    public async Task<IActionResult> GetCourseById(Guid id)
    {
        if (id != Guid.Empty)
        {
            var result = await _courseService.GetCourseById(id);
            return Ok(result);
        }
        else
        {
            return BadRequest();
        }
    }


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

    [HttpPut("editcourse")]
    public async Task<IActionResult> EditCourse(CourseDto courseDto)
    {
        if(courseDto != null)
        {
            var updatedCourse = await _courseService.EditCourse(courseDto);
            return Ok(updatedCourse);
        }
        else
        {
            return NoContent();
        }
    }

    [HttpDelete("removecourse/{id:guid}")]
    public async Task<IActionResult> RemoveCourse(Guid id)
    {
        if (id != Guid.Empty)
        {
            var result = await _courseService.DeleteCourseById(id);
            return Ok($"course {result} with id: {id} was removed");
        }
        else
        {
            return BadRequest();
        }
    }
}
