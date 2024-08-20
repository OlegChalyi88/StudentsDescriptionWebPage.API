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
    //todo for Veronika: під час створення профілю студента необхідно присвоїти йому номер картки, засетити йому 
    // false для властивості isGraduted. І зробити аби між полями віку і дати народження не було розбіжностей.
    public async Task CreateProfileForStudent(StudentProfileRequestDto studentProfileDto)
    {
        var studentProfile = _mapper.Map<StudentProfile>(studentProfileDto);
        studentProfile.StudentCardNumber = Guid.NewGuid().ToString();//rewrite to 6 digits

        await _studentProfileRepository.AddRecordForStudentProfile(studentProfile);
    }
    //todo for Illia: implement based on changeCardNumber value, value for StudentCardNumber
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
