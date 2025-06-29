﻿
namespace StudentManagementSystem.Application.Dtos.Subject.Requests
{
    public class SubjectRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int YearLevel { get; set; }
        public string Semester { get; set; } = string.Empty;

        public string CourseCode { get; set; } = string.Empty;
    }
}
