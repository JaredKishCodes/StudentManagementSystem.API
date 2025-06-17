using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Dtos
{
    public class StudentDTO
    {
        
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public string Course { get; set; } = null!;
    }
}
