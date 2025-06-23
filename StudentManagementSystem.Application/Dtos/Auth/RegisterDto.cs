
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Application.Dtos.Auth
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
