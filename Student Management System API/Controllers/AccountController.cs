using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System_API.Helpers;
using StudentManagementSystem.Application.Auth.Commands;
using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.Dtos.Auth;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(ISender sender) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var result = await sender.Send(new LoginCommand(loginDto));

                if (!result.Succeeded)
                    return Unauthorized(new { message = result.Error });

                return Ok(result.Data);
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

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var result = await sender.Send(new RegisterCommand(registerDto));

                if (!result.Succeeded)
                    return Unauthorized(new { message = result.Error });

                return Ok(result.Data);
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
