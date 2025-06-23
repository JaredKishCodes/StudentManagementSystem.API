using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System_API.Helpers;
using StudentManagementSystem.Application.Dtos.Subject.Requests;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Subjects.Commands;
using StudentManagementSystem.Application.Subjects.Queries;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(ISender sender) : ControllerBase
    {
        [HttpGet("GetAllSubjects")]
        public async Task<ActionResult<IEnumerable<SubjectRequestDto>>> GetAllSubjects()
        {
            try
            {
                var result = await sender.Send(new GetSubjectsQuery());

                return Ok(new ApiResponse<IEnumerable<SubjectResponseDto>>
                {
                    Success = true,
                    Message = "Subjects fetched Successfully",
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
        public async Task<ActionResult<SubjectRequestDto>> GetSubjectByid(int id)
        {
            try
            {
                var result = await sender.Send(new GetSubjectByIdQuery(id));

                return Ok(new ApiResponse<SubjectResponseDto>
                {
                    Success = true,
                    Message = "Subject fetched Successfully",
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
        [HttpPost("AddSubject")]
        public async Task<ActionResult<SubjectRequestDto>> AddSubjectAsync(SubjectRequestDto subjectRequestDto)
        {
            try
            {
                var result = await sender.Send(new AddSubjectCommand(subjectRequestDto));

                return Ok(new ApiResponse<SubjectResponseDto>
                {
                    Success = true,
                    Message = "Subject added Successfully",
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
        public async Task<ActionResult<SubjectRequestDto>> UpdateSubjectAsync(int id, SubjectRequestDto subjectRequestDto)
        {
            try
            {
                var result = await sender.Send(new UpdateSubjectCommand(id, subjectRequestDto));

                return Ok(new ApiResponse<SubjectResponseDto>
                {
                    Success = true,
                    Message = "Subject updated Successfully",
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
        public async Task<ActionResult<bool>> DeleteSubjectAsync(int id)
        {
            try
            {
                var result = await sender.Send(new DeleteSubjectCommand(id));

                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = "Subject deleted Successfully",
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
