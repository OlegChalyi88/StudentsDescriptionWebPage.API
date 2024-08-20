namespace Repository.Models.DataTransferObject;
//todo: based on todo Veronika change the same 
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
// changeCardNumber