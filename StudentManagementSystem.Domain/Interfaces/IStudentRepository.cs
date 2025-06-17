using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);

        Task<bool> FindbyEmailAsync(string email);
        Task<Student> AddStudent(Student student);  
        Task<Student> UpdateStudent(int id,Student student);
        Task<bool> DeleteStudentAsync(int id);

    }
}
