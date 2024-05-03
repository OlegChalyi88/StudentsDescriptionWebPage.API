using AutoMapper;
using Repository.Interfaces;
using Repository.Models.DataTransferObject;
using Repository.Models.Domain;
using Service.Interfaces;

namespace Service.Repositories;

public class StudentProfileService : IStudentProfileService
{
    private readonly IMapper _mapper;
    private readonly IStudentProfileRepository _studentProfileRepository;

    public StudentProfileService(IMapper mapper, IStudentProfileRepository studentProfileRepository)
    {
        _mapper = mapper;
        _studentProfileRepository = studentProfileRepository;
    }

    public async Task CreateProfileForStudent(StudentProfileRequestDto studentProfile)
    {
        StudentProfile stProf = new StudentProfile();
        stProf.FirstName = studentProfile.FirstName;
        stProf.LastName = studentProfile.LastName;
        stProf.DateOfBirth = studentProfile.DateOfBirth;
        stProf.Description = studentProfile.Description;
        stProf.Age = studentProfile.Age;

        await _studentProfileRepository.AddRecordForStudentProfile(stProf);
    }

    public async Task<StudentProfile> EditProfileForStudent(StudentProfileEditRequestDto studentProfileDto)
    {
        var studentProfile = await _studentProfileRepository.GetStudentProfileById(studentProfileDto.Id);
        var mapped = _mapper.Map(studentProfileDto, studentProfile);

        return await _studentProfileRepository.UpdateRecordForStudentProfile(mapped);
    }

    public async Task<IEnumerable<StudentProfile>> GetStudentProfiles()
    {
        return await _studentProfileRepository.RetrieveStudentProfiles();
    }

    public async Task DeleteStudentProfile(Guid id)
    {
        await _studentProfileRepository.RemoveStudentProfile(id);
    }
}
