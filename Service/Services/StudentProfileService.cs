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
    private readonly Random _random;

    public StudentProfileService(IMapper mapper, IStudentProfileRepository studentProfileRepository)
    {
        _mapper = mapper;
        _studentProfileRepository = studentProfileRepository;
        _random = new Random();
    }
    //todo for Veronika: під час створення профілю студента необхідно присвоїти йому номер картки, засетити йому 
    // false для властивості isGraduted. І зробити аби між полями віку і дати народження не було розбіжностей.
    public async Task CreateProfileForStudent(StudentProfileRequestDto studentProfileDto)
    {
        var studentProfile = _mapper.Map<StudentProfile>(studentProfileDto);

        studentProfile.StudentCardNumber = _random.Next(100000, 1000000).ToString(); // 6 digits (100000 - 999999)
        studentProfile.IsGraduated = false; // it was not necessary because the property StudentProfile.IsGraduated is already false by default
        
        if (studentProfile.DateOfBirth.HasValue)
            studentProfile.Age = CalculateAge(studentProfile.DateOfBirth.Value);

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

    private int CalculateAge(DateTime dateOfBirth)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - dateOfBirth.Year;

        // if the birthday has already occurred this year - subtract one year
        if (dateOfBirth > today.AddYears(-age))
            age--;

        return age;
    }
}
