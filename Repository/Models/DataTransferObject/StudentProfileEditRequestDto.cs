namespace Repository.Models.DataTransferObject;

public record StudentProfileEditRequestDto(
    Guid Id,
    string FirstName,
    string LastName,
    string? Description,
    int? Age,
    DateTime? DateOfBirth,
    bool IsProfileVisible);
