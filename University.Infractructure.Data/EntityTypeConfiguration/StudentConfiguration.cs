using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Core;

namespace University.Infrastructure.Data.EntityTypeConfiguration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("STUDENTS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("STUDENT_ID");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FIRST_NAME");

            builder.Property(e => e.GroupId)
                .HasColumnName("GROUP_ID");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");

            builder.HasOne(d => d.Group)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("STUDENTS_GROUP");
        }
    }
}