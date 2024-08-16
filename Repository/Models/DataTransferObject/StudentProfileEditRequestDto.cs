namespace Repository.Models.DataTransferObject;

public record StudentProfileEditRequestDto(
    Guid Id,
    string FirstName,
    string LastName,
    string StudentLogin,
    string? Description,
    int? Age,
    bool IsGraduated,
    DateTime? DateOfBirth,
    bool IsProfileVisible);
