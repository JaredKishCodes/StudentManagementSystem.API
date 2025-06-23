
namespace StudentManagementSystem.Application.Dtos.Auth
{
    
        public class AuthResponseDto
        {
            public string Message { get; set; } = string.Empty;
            public bool Status { get; set; }
            public string Token { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
        }

    }

