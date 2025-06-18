using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Courses.Query
{   
    public record GetAllCoursesQuery() : IRequest<IEnumerable<CourseDto>>;
    public class GetAllCoursesQueryHandler(ICourseService _courseService)
        : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
    {
        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _courseService.GetCoursesAsync();
        }
    }
}
