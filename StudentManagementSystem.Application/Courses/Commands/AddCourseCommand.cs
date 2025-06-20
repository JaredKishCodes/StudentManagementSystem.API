﻿
using MediatR;
using StudentManagementSystem.Application.Dtos.Course.Requests;
using StudentManagementSystem.Application.Dtos.Course.Response;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;



namespace StudentManagementSystem.Application.Courses.Commands
{   
    public record AddCourseCommand(CourseRequestDto course) : IRequest<CourseDto>;
    public class AddCourseCommandHandler(ICourseService _courseService)
        : IRequestHandler<AddCourseCommand, CourseDto>
    {
        public async Task<CourseDto> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var newCourse = new CourseRequestDto
            {
                Name = request.course.Name,
                Code = request.course.Code,
                Description = request.course.Description,
                Units = request.course.Units,
                Department = request.course.Department,
            };

            var createdCourse = await _courseService.AddCourseAsync(newCourse);

            return new CourseDto
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
                Code = createdCourse.Code,
                Description = createdCourse.Description,
                Units = createdCourse.Units,
                Department = createdCourse.Department
            };



        }
    }
}
