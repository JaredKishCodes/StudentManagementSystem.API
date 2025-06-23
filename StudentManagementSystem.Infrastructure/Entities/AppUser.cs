
using Microsoft.AspNetCore.Identity;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure.Entities
{
    public class AppUser : IdentityUser, IUserBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        
    }
}
