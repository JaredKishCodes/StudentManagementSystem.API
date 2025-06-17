using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.Property(t => t.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(20).IsRequired();
            builder.Property(t => t.BirthDate).IsRequired();
            builder.Property(t => t.Gender).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(30).IsRequired();
            builder.Property(t => t.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(t => t.Address).HasMaxLength(50).IsRequired();
            builder.Property(t => t.EnrollmentDate).IsRequired();
            
            builder.HasOne(u => u.Course)
                .WithMany(u => u.Students)
                .HasForeignKey(u => u.CourseId);

        }
    }
}
