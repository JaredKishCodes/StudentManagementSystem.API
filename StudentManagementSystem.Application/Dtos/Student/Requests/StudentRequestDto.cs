﻿
using System.ComponentModel.DataAnnotations;


namespace StudentManagementSystem.Application.Dtos.Student.Requests
{
    public class StudentRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;  

        // Contact Info
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

        // Academic Info
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        

        public string Code { get; set; } = null!;

        public int CourseId { get; set; }

    }
}


  

