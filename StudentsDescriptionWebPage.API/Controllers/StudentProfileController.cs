using Microsoft.AspNetCore.Mvc;
using Repository.Models.DataTransferObject;
using Service.Interfaces;

namespace StudentsDescriptionWebPage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentProfileController : ControllerBase
{
    private readonly IStudentProfileService _studentProfileService;

    public StudentProfileController(IStudentProfileService studentProfileService)
    {
        _studentProfileService = studentProfileService;
    }

    [HttpPost("profile")]
    public async Task<IActionResult> CreateProfile([FromBody]StudentProfileRequestDto studentProfile)
    {
        await _studentProfileService.CreateProfileForStudent(studentProfile);

        return Ok();
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _studentProfileService.GetStudentProfiles();

        return Ok(students);
    }

    [HttpPut("student/edit/profile")]
    public async Task<IActionResult> EditProfile(StudentProfileEditRequestDto studentProfile)
    {
        var response = await _studentProfileService.EditProfileForStudent(studentProfile);

        return Ok(response);
    }

    [HttpDelete("student/{id:guid}")]
    public async Task<IActionResult> RemoveStudent(Guid id)
    {
        await _studentProfileService.DeleteStudentProfile(id);

        return Ok();
    }
}
