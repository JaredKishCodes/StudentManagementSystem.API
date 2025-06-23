
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;    
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure.Entities;

namespace StudentManagementSystem.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
                                : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "admin-role-id",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "user-role-id",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

    
