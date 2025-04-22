using Repository.Models.Domain;

namespace Repository.Models.DataTransferObject.Course;

public record CourseDto(
            Guid Id,
            string GroupName,
            string TitleOfCourse,
            string Trener,
            DateTime StartDateOfCourse,
            CurrentCourse CurrentCourse
            );
