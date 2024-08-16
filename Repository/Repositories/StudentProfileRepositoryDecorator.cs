using Microsoft.EntityFrameworkCore;
using Repository.AdditionalHelper;
using Repository.Data;
using Repository.Interfaces;
using Repository.Models.Domain;

namespace Repository.Repositories;

public class StudentProfileRepositoryDecorator : IStudentProfileRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IStudentProfileRepository _studentProfileRepository;

    public StudentProfileRepositoryDecorator(AppDbContext appDbContext, IStudentProfileRepository studentProfileRepository)
    {
        _appDbContext = appDbContext;
        _studentProfileRepository = studentProfileRepository;
    }

    public async Task AddRecordForStudentProfile(StudentProfile stProf)
    {
        var res = await _appDbContext.StudentProfiles.Where(x => x.StudentCardNumber == stProf.StudentCardNumber).FirstOrDefaultAsync();

        if (res != null)
        {
            throw new Exception(string.Format(Constants.CardAlreadyExist, stProf.StudentCardNumber));
        }

        await _studentProfileRepository.AddRecordForStudentProfile(stProf);
    }

    public async Task<IEnumerable<StudentProfile>> RetrieveStudentProfiles()
    {
        var result = await _studentProfileRepository.RetrieveStudentProfiles();

        return result;
    }

    public async Task<StudentProfile> GetStudentProfileById(Guid id)
    {
        var studentProfile = await _appDbContext.StudentProfiles.FindAsync(id);

        if (studentProfile == null)
        {
            throw new Exception(string.Format(Constants.NotFoundEntity, id));
        }

        return studentProfile;
    }

    public async Task<StudentProfile> UpdateRecordForStudentProfile(StudentProfile studentProfile)
    {
        var student = _appDbContext.StudentProfiles.Update(studentProfile).Entity;
        await _appDbContext.SaveChangesAsync();

        return student;
    }

    public async Task RemoveStudentProfile(Guid id)
    {
        var profile = await _appDbContext.StudentProfiles.Where(sp => sp.Id == id).SingleOrDefaultAsync();

        if (profile == null)
        {
            throw new Exception(string.Format(Constants.NotFoundEntity, id));
        }

        await _studentProfileRepository.RemoveStudentProfile(id);
    }
}
