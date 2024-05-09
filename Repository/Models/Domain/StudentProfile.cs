namespace Repository.Models.Domain
{
    public class StudentProfile
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentLogin { get; set; } = string.Empty;
        public string StudentCardNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? Age { get; set; }
        public string? Image { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsGraduated { get; set; } = false;
        public bool IsProfileVisible { get; set; } = true;
        public AdditionalInfo? AdditionalInfo { get; set; }
    }
}
