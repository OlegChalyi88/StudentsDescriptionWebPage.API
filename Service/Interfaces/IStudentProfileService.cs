using Repository.Models.DataTransferObject;
using Repository.Models.Domain;

namespace Service.Interfaces;

public interface IStudentProfileService
{
    Task CreateProfileForStudent(StudentProfileRequestDto studentProfile);
    Task<IEnumerable<StudentProfile>> GetStudentProfiles();
    Task<StudentProfile> EditProfileForStudent(StudentProfileEditRequestDto studentProfile);
    Task DeleteStudentProfile(Guid id);
}
