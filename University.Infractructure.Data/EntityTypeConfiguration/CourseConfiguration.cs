using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Core;

namespace University.Infrastructure.Data.EntityTypeConfiguration
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("COURSES");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name, "COURSES__INDEX")
                .IsUnique();

            builder.Property(e => e.Id)
                .IsRequired()
                .HasColumnName("COURSE_ID");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("NAME");
        }
    }
}