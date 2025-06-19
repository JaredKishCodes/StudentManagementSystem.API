using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Application.Dtos.Student.Requests;
using StudentManagementSystem.Application.Dtos.Student.Response;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Services
{
    public class StudentService(IStudentRepository _studentRepository,ICourseRepository _courseRepository) : IStudentService
    {
        public async Task<StudentDTO> AddStudent(Student student)
        {
            bool emailExists = await _studentRepository.FindbyEmailAsync(student.Email);
            if (emailExists)
            {
                throw new Exception("A student with this email already exists.");
            }

            var createdStudent =  await _studentRepository.AddStudent(student);

            return new StudentDTO { 
                Id = createdStudent.Id,
                FirstName = createdStudent.FirstName,
                LastName = createdStudent.LastName,
                Email = createdStudent.Email,
                EnrollmentDate = createdStudent.EnrollmentDate,
                Course = new CourseSummaryDto
                {
                    Name = student.Course.Name,
                    SubjectCount = student.Course.Subjects.Count
                },
            };

        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
          var toBeDeleted =   await _studentRepository.GetStudentByIdAsync(id);
            if (toBeDeleted == null)
            {
                throw new Exception("Student ID can not be found");
            }
           await _studentRepository.DeleteStudentAsync(id);
           return true;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            if (!students.Any())
                throw new Exception("No students found.");

            return students.Select(student => new StudentDTO {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                EnrollmentDate = student.EnrollmentDate,
                Course = new CourseSummaryDto
                {
                    Name = student.Course.Name,
                    SubjectCount = student.Course.Subjects.Count
                },
            });
            

        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id can not be found");
            }
           var result =   await _studentRepository.GetStudentByIdAsync(id);

            return new StudentDTO
            {   
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                EnrollmentDate = result.EnrollmentDate,
                Course = new CourseSummaryDto
                {
                    Name = result.Course.Name,
                    SubjectCount = result.Course.Subjects.Count
                },
            };
        }

        public async Task<StudentDTO> UpdateStudent(int id, Student student)
        {
            if (id <= 0) throw new Exception("Invalid student ID");

            var existing = await _studentRepository.GetStudentByIdAsync(id);
            if (existing == null) throw new Exception("Student not found");

            
            var course = await _courseRepository.GetCourseByNameAsync(student.Course.Name);
            if (course == null)
                throw new Exception("Course not found");

            
            student.CourseId = course.Id;

            var result = await _studentRepository.UpdateStudent(id, student);

            return new StudentDTO
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                EnrollmentDate = result.EnrollmentDate,
                Course = new CourseSummaryDto
                {
                    Name = result.Course.Name,
                    SubjectCount = result.Course.Subjects.Count
                },
            };
        }

    }
}
