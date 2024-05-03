using Repository.Models.DataTransferObject;
using Repository.Models.Domain;

namespace Repository.Interfaces;

public interface IStudentProfileRepository
{
    Task AddRecordForStudentProfile(StudentProfile stProf);
    Task<IEnumerable<StudentProfile>> RetrieveStudentProfiles();
    Task<StudentProfile> GetStudentProfileById(Guid id);
    Task<StudentProfile> UpdateRecordForStudentProfile(StudentProfile studentProfile);
    Task RemoveStudentProfile(Guid id);
}
