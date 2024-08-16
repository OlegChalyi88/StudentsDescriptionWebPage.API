
namespace Repository.Models.DataTransferObject;

//todo for Veronika: delete from dto StudentCardNumber, IsGraduated, Age.
// DateOfBirth and Age would according each other.
public record StudentProfileRequestDto(
    string FirstName,
    string LastName,
    string StudentLogin,
    string StudentCardNumber,
    string? Description,
    int? Age,
    bool IsGraduated,
    DateTime? DateOfBirth);
