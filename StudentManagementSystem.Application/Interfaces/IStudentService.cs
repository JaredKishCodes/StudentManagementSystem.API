using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<StudentDTO> AddStudent(Student student);
        Task<StudentDTO> UpdateStudent(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
