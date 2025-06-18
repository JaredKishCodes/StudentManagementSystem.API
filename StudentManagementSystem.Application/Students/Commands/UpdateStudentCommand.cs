

using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Students.Commands
{
    public record UpdateStudentCommand(int id, StudentRequestDto studentRequestDto) :IRequest<StudentDTO>;

    public class UpdateStudentCommandHandler(IStudentService _studentService,ICourseRepository _courseRepository)
        : IRequestHandler<UpdateStudentCommand, StudentDTO>

    {
        public async Task<StudentDTO> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetCourseByCodeAsync(request.studentRequestDto.Code);
            if (course == null)
                throw new Exception("Course not found");

            var studentToUpdate = new Student
            {
                Id = request.id,
                FirstName = request.studentRequestDto.FirstName,
                LastName = request.studentRequestDto.LastName,
                BirthDate = request.studentRequestDto.BirthDate,
                Gender = request.studentRequestDto.Gender,
                Email = request.studentRequestDto.Email,
                PhoneNumber = request.studentRequestDto.PhoneNumber,
                Address = request.studentRequestDto.Address,
                EnrollmentDate = request.studentRequestDto.EnrollmentDate,
                Course = course
            };

            var updatedStudent = await _studentService.UpdateStudent(studentToUpdate.Id, studentToUpdate);

            return new StudentDTO
            {
                FirstName = updatedStudent.FirstName,
                LastName = updatedStudent.LastName,
                Email = updatedStudent.Email,
                EnrollmentDate = updatedStudent.EnrollmentDate,
                Course = updatedStudent.Course,
            };
        }
    }
}
