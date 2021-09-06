﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.Infrastructure.Data;

namespace University.Infrastructure.Data.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20210706202838_CreateAndFillTestDataDb")]
    partial class CreateAndFillTestDataDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("University.Domain.Core.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("COURSE_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "COURSES__INDEX")
                        .IsUnique();

                    b.ToTable("COURSES");
                });

            modelBuilder.Entity("University.Domain.Core.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GROUP_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("COURSE_ID");                    

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex(new[] { "Name" }, "GROUPS_INDEX")
                        .IsUnique();

                    b.ToTable("GROUPS");
                });

            modelBuilder.Entity("University.Domain.Core.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("STUDENT_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GROUP_ID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("STUDENTS");
                });

            modelBuilder.Entity("University.Domain.Core.Group", b =>
                {
                    b.HasOne("University.Domain.Core.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("GROUPS_COURSE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("University.Domain.Core.Student", b =>
                {
                    b.HasOne("University.Domain.Core.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("STUDENTS_GROUP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("University.Domain.Core.Course", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("University.Domain.Core.Group", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
