using Microsoft.EntityFrameworkCore;
using Repository.Models.Domain;

namespace Repository.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<StudentProfile> StudentProfiles { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<AdditionalInfo> AdditionalInfos { get; set; }
}
