namespace Repository.Models.Domain
{
    //[Index(nameof(StudentLogin), IsUnique = true)]
    public class StudentProfile
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //[StringLength(255), Required]
        public string StudentLogin { get; set; }
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
