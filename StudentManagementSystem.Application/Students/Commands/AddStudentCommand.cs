using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Students.Commands
{
    public record AddStudentCommand(StudentRequestDto studentRequestDto) : IRequest<StudentDTO>;

    public class AddStudentCommandHandler(IStudentService studentService, ICourseService courseService,ICourseRepository courseRepository)
        : IRequestHandler<AddStudentCommand, StudentDTO>
    {
        public async Task<StudentDTO> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var code = await courseRepository.GetCourseByCodeAsync(request.studentRequestDto.Code);
            
            if (code == null)
            {
                throw new Exception("Course not found");
            }

            var newStudent = new Student
            {
                FirstName = request.studentRequestDto.FirstName,
                LastName = request.studentRequestDto.LastName,
                BirthDate = request.studentRequestDto.BirthDate,
                Gender = request.studentRequestDto.Gender,
                Email = request.studentRequestDto.Email,
                PhoneNumber = request.studentRequestDto.PhoneNumber,
                Address = request.studentRequestDto.Address,
                EnrollmentDate = request.studentRequestDto.EnrollmentDate,
                Course = code,
                
                
               
            };

            var createdStudent = await studentService.AddStudent(newStudent);

            return new StudentDTO
            {
                FirstName = createdStudent.FirstName,
                LastName = createdStudent.LastName,
                Email = createdStudent.Email,
                EnrollmentDate = createdStudent.EnrollmentDate,
                Course = createdStudent.Course
            };
        }
    }
}
