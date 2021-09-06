using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Core;

namespace University.Infrastructure.Data.EntityTypeConfiguration
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("GROUPS");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name, "GROUPS_INDEX")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("GROUP_ID");

            builder.Property(e => e.CourseId)
                .HasColumnName("COURSE_ID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NAME");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.Groups)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GROUPS_COURSE");
        }
    }
}