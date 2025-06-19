
namespace StudentManagementSystem.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int YearLevel { get; set; }
        public string Semester { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
