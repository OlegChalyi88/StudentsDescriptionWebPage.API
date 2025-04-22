
namespace Repository.Models.DataTransferObject;

//todo for Veronika: delete from dto StudentCardNumber, IsGraduated, Age.
// DateOfBirth and Age would according each other.
//public record StudentProfileRequestDto(
//    string? FirstName,
//    string? LastName,
//    string? StudentLogin,
//    string? Description,
//    DateTime? DateOfBirth);

public class StudentProfileRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentLogin { get; set; }
    public string? Description { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
