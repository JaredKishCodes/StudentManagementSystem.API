using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System_API.Helpers;
using StudentManagementSystem.Application.Dtos.Student.Requests;
using StudentManagementSystem.Application.Dtos.Student.Response;
using StudentManagementSystem.Application.Students.Commands;
using StudentManagementSystem.Application.Students.Query;
using StudentManagementSystem.Domain.Entities;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollStudentController(ISender sender) : ControllerBase
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
                    Data = ex.InnerException?.Message ?? ex.Message
                });
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            try
            {
                var result = await sender.Send(new GetAllStudentsQuery());
                return Ok(new ApiResponse<IEnumerable<StudentDTO>>
                {
                    Success = true,
                    Message = "Students fetched sucessfully!",
                    Data = result,
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentDTO>> GetStudentByIdAsync(int id)
        {
            try
            {
                var result = await sender.Send(new GetStudentByIdQuery(id));
                return Ok(new ApiResponse<StudentDTO>
                {
                    Success = true,
                    Message = "Student fetched sucessfully!",
                    Data = result,
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StudentDTO>> UpdateStudentAsync(int id,StudentRequestDto studentRequestDto)
        {
            try
            {
                var result = await sender.Send(new UpdateStudentCommand(id,studentRequestDto));
                return Ok(new ApiResponse<StudentDTO>
                {
                    Success = true,
                    Message = "Student Updated sucessfully!",
                    Data = result,
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteStudentAsync(int id)
        {
            try
            {
                var result = await sender.Send(new DeleteStudentCommand(id));
                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = "Student deleted sucessfully!",
                    Data = result,
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