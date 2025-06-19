
using MediatR;
using StudentManagementSystem.Application.Dtos.Course.Requests;
using StudentManagementSystem.Application.Dtos.Course.Response;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Courses.Commands
{   
    public record UpdateCourseCommand(int id, CourseRequestDto courseRequestDto) : IRequest<CourseDto>;
    public class UpdateCourseCommandHandler(ICourseService _courseService)
        : IRequestHandler<UpdateCourseCommand, CourseDto>
    {
        public async Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            return await _courseService.UpdateCourseAsync(request.id, request.courseRequestDto);
        }
    }
}
