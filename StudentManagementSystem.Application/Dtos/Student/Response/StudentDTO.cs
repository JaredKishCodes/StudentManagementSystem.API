using StudentManagementSystem.Application.Dtos.Student.Requests;

namespace StudentManagementSystem.Application.Dtos.Student.Response
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public CourseSummaryDto Course { get; set; } = null!;
    }
}
