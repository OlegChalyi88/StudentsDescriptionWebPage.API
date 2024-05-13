
namespace Repository.Models.DataTransferObject;

public record StudentProfileRequestDto(
    string FirstName,
    string LastName,
    string StudentLogin,
    string StudentCardNumber,
    string? Description,
    int? Age,
    bool IsGraduated,
    DateTime? DateOfBirth);
