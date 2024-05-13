using Repository.Models.Domain;

namespace Repository.Models.DataTransferObject.Course;

public record CourseDto(
            string GroupName,
            string TitleOfCourse,
            string TeacherName,
            DateTime StartDateOfCourse,
            CurrentCourse CurrentCourse
            );
