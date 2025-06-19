using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;
using StudentManagementSystem.Infrastructure.Data;

namespace StudentManagementSystem.Infrastructure.Repositories
{
    public class StudentRepository(AppDbContext _dbContext) : IStudentRepository
    {
        public async Task<Student> AddStudent(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            
            return await _dbContext.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.Id == student.Id);
        }


        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student  = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student is not null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> FindbyEmailAsync(string email)
        {
            return email != null && await _dbContext.Students.AnyAsync(x => x.Email == email);
        }

       

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _dbContext.Students
                    .Include(s => s.Course)
                    .ThenInclude(s => s.Subjects) 
                    .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _dbContext.Students
                .Include(x => x.Course)
                .ThenInclude(x => x.Subjects)
                .FirstOrDefaultAsync(x => x.Id == id);

            return student;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent is not null) {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.Gender = student.Gender;
                existingStudent.Email = student.Email;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.Address = student.Address;
                existingStudent.CourseId = student.CourseId;

                await _dbContext.SaveChangesAsync();
                return existingStudent; 
            }
            return null;
        }
    }
}
