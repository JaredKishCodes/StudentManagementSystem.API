using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System_API.Helpers;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Students.Commands;
using StudentManagementSystem.Domain.Entities;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<StudentDTO>>> AddStudent([FromBody] StudentRequestDto student)
        {
            try
            {
                var result = await sender.Send(new AddStudentCommand(student));
                return Ok(new ApiResponse<StudentDTO>
                {
                    Success = true,
                    Message = "Student added sucessfully!",
                    Data = result
                });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    Data = ex.Message // Or null
                });
            }
            
        }
    }
}
