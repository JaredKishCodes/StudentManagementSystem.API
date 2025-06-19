

namespace StudentManagementSystem.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Academic Info
        public int Units { get; set; }           
        public string? Department { get; set; }


        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
