

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.YearLevel).IsRequired();
            builder.Property(x => x.Semester).HasMaxLength(10).IsRequired();

            builder.HasOne(u => u.Course)
                 .WithMany(u => u.Subjects)
                 .HasForeignKey(u => u.CourseId);
        }
    }
}
