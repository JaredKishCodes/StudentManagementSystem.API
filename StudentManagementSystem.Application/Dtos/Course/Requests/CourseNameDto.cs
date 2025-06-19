
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentManagementSystem.Application.Dtos.Course.Requests
{
    public class CourseNameDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
