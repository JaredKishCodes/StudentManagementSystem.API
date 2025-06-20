
using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Infrastructure.Entities
{
    public class AppUser : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
    }
}
