

using MediatR;
using StudentManagementSystem.Application.Dtos.Course.Response;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Courses.Query
{   
    public record GetCourseById(int id) : IRequest<CourseDto>;
    public class GetCourseByIdHandler(ICourseService _courseService)
        : IRequestHandler<GetCourseById, CourseDto>
    {
        public async Task<CourseDto> Handle(GetCourseById request, CancellationToken cancellationToken)
        {
            return await _courseService.GetCourseByIdAsync(request.id);
        }
    }
}
