namespace Repository.Models.Domain;

public class AdditionalInfo
{
    public Guid Id { get; set; }
    public Course Course { get; set;}
    public IEnumerable<Course> AllCourses { get; set;} = Enumerable.Empty<Course>();
    public string? Hobbies { get; set; }
    public string? Education { get;}
    public string? CurrentJob { get; set; }
    public Resume? Resume { get; set; }
}
