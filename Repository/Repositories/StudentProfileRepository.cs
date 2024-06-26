﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.AdditionalHelper;
using Repository.Data;
using Repository.Interfaces;
using Repository.Models.Domain;
using System.Data;
using System.Transactions;

namespace Repository.Repositories;

public class StudentProfileRepository : IStudentProfileRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentProfileRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddRecordForStudentProfile(StudentProfile stProf)
    {
        await _appDbContext.StudentProfiles.AddAsync(stProf);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<StudentProfile>> RetrieveStudentProfiles()
    {
        var result = await _appDbContext.StudentProfiles
                            .Include(stProf => stProf.AdditionalInfo)
                            .ThenInclude(addInfo => addInfo.Course)
                            .ToListAsync();

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
        var profile = await _appDbContext.StudentProfiles.Where(sp => sp.Id == id).SingleAsync();

        using (TransactionScope tran = new TransactionScope())
        {
            _appDbContext.StudentProfiles.Remove(profile);
            await _appDbContext.SaveChangesAsync();
            tran.Complete();
        }
        
    }
}
