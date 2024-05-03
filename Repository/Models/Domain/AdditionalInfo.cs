namespace Repository.Models.Domain;

public class AdditionalInfo
{
    public Guid Id { get; set; }
    public Course CurrentCourse { get; set;}
    public IEnumerable<Course> AllCourses { get; set;}
    public string Hobbies { get; set; }
    public string Education { get;}
    public string CurrentJob { get; set; }
}
