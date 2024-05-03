
namespace Repository.Models.DataTransferObject;

public record StudentProfileRequestDto(
    string FirstName,
    string LastName,
    string? Description,
    int? Age,
    DateTime? DateOfBirth);
