namespace Repository.Models.Domain;

public class Course
{
    public Guid Id { get; set; }
    public string GroupName { get; set;}
    public string TitleOfCourse { get; set;}
    public string TeacherName { get; set; }
    public DateTime StartDateOfCourse { get; set; }
    public CurrentCourse CurrentCourse { get; set; }
}
