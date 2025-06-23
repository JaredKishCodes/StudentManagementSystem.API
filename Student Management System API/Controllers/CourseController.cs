using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System_API.Helpers;
using StudentManagementSystem.Application.Courses.Commands;
using StudentManagementSystem.Application.Courses.Query;
using StudentManagementSystem.Application.Dtos.Course.Requests;
using StudentManagementSystem.Application.Dtos.Course.Response;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ISender sender) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("AddCourse")]
        public async Task<ActionResult<CourseDto>> AddCourseAsync(CourseRequestDto course)
        {
            try
            {
                var result = await sender.Send(new AddCourseCommand(course));

                if (result == null)
                {
                    return NotFound("No courses were found");
                }

                return Ok(new ApiResponse<CourseDto>
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
                    Data = ex.InnerException?.Message ?? ex.Message
                });
            }

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCoursesAsync()
        {
            try
            {
                var result = await sender.Send(new GetAllCoursesQuery());

                if (result == null || !result.Any())
                {
                    return StatusCode(200, new ApiResponse<string>
                    {
                        Success = false,
                        Message = "No courses were found.",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<IEnumerable<CourseDto>>
                {
                    Success = true,
                    Message = "Course fetched successfully!",
                    Data = result
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Data = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseDto>> GetCourseByIdAsync(int id)
        {
            try
            {
                var result = await sender.Send(new GetCourseById(id));
                return Ok(new ApiResponse<CourseDto>
                {
                    Success = true,
                    Message = "Course fetched successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Data = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CourseDto>> UpdateCourseAsync(int id, CourseRequestDto courseReqDto)
        {
            try
            {
                var result = await sender.Send(new UpdateCourseCommand(id, courseReqDto));

                return Ok(new ApiResponse<CourseDto>
                {
                    Success = true,
                    Message = "Course updated sucessfully!",
                    Data = result
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Data = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCourseAsync(int id)
        {
            try
            {
                var result = await sender.Send(new DeleteCourseCommand(id));
                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = "Course deleted successfully!",
                    Data = result

                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string> 
                { 
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Data = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
