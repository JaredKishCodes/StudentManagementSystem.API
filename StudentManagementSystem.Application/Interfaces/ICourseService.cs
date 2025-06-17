using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface ICourseService
    {
        Task<ICollection<CourseDto>> GetCoursesAsync();
        Task<CourseDto> GetCourseByNameAsync(string name);
        Task<CourseDto> AddCourseAsync(CourseRequestDto course);
        Task<CourseDto> UpdateCourseAsync(int id, CourseRequestDto course);
        Task<bool> DeleteCourseAsync(int id);
        Task<CourseDto> GetCourseByIdAsync(int id);
    }
}
