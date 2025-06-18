

namespace StudentManagementSystem.Application.Dtos
{
   public  class CourseRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Units { get; set; }
        public string? Department { get; set; }
    }
}
