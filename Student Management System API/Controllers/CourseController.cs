using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System_API.Helpers;
using StudentManagementSystem.Application.Courses.Commands;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Domain.Entities;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CourseDto>> AddCourseAsync(CourseRequestDto course)
        {
            try
            {
                var result = await sender.Send(new AddCourseCommand(course));
                return Ok( new ApiResponse<CourseDto>
                {
                    Success = true,
                    Message = "Course added Successfully!",
                    Data = result
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Data = ex.Message 
                });
            }
        }
    }
}
