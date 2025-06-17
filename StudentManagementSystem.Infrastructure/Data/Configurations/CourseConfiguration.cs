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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x =>x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Units).IsRequired();
            builder.Property(x => x.Department).IsRequired();

            builder.HasMany(x => x.Students)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);


        }
    }
}
