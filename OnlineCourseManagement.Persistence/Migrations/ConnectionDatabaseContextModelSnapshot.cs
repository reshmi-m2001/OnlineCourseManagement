﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCourseManagement.Persistence.DatabaseContext;

#nullable disable

namespace OnlineCourseManagement.Persistence.Migrations
{
    [DbContext(typeof(ConnectionDatabaseContext))]
    partial class ConnectionDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OnlineCourseManagement.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CourseLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Duration")
                        .HasColumnType("double");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CourseCategoryId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseCategoryId = 1,
                            CourseLink = "https://www.cloudskillsboost.google/paths/249/course_templates/1135",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6077),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6078),
                            Description = "The Gemini in Google Drive course introduces you to Gemini, an AI-powered tool integrated within Google Drive. Learn how to leverage Gemini's capabilities to enhance document management, streamline workflows, and improve collaboration. This course covers everything from setup to advanced features, empowering you to maximize productivity and efficiency using AI-driven insights in Google Drive.",
                            Duration = 1.0,
                            Instructor = "Google Cloud",
                            Title = "Gemini in Google Drive"
                        },
                        new
                        {
                            Id = 2,
                            CourseCategoryId = 2,
                            CourseLink = "https://www.learnvern.com/soft-skills-training/introduction-to-communication-skills-and-types",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6081),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6082),
                            Description = "In order to succeed in the workplace, it is important that you are able to communicate with others and deliver your point effectively. You should also be able to listen carefully and respond appropriately.",
                            Duration = 1.5,
                            Instructor = "Learn Vern",
                            Title = "Communication Skills and Its Types"
                        },
                        new
                        {
                            Id = 3,
                            CourseCategoryId = 2,
                            CourseLink = "https://www.learnvern.com/soft-skills-training/time-management-skills",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6084),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6085),
                            Description = "Time management skills can be divided into two categories: personal time management and professional time management. Personal time management includes things like prioritizing, goal setting, scheduling, self-discipline, and self-control. Professional time management includes things like planning, organizing, delegation, delegation of tasks, collaboration with co-workers, meeting deadlines.",
                            Duration = 1.5,
                            Instructor = "Learn Vern",
                            Title = "Time Management"
                        },
                        new
                        {
                            Id = 4,
                            CourseCategoryId = 1,
                            CourseLink = "https://www.youtube.com/watch?v=E6sUJWwZLwE",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6088),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6088),
                            Description = "Building an ASP.NET Core 8 Web API using Clean Architecture involves structuring the application into distinct layers: Presentation, Application, Domain, and Infrastructure. The Presentation Layer handles HTTP requests and responses through API controllers, while the Application Layer manages business logic and use cases. The Domain Layer defines core business entities and rules, and the Infrastructure Layer deals with data access and external services. This approach ensures a modular, maintainable, and testable codebase.",
                            Duration = 1.5,
                            Instructor = "YouTube - Fullstack Dev",
                            Title = "ASP.NET Core 8 Web API in Clean architecture from scratch"
                        },
                        new
                        {
                            Id = 5,
                            CourseCategoryId = 2,
                            CourseLink = "https://www.learnvern.com/soft-skills-training/define-problem",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6091),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6092),
                            Description = "The act of describing a problem, discovering the origin of the problem, identifying, prioritising, and selecting potential solutions for a solution, and implementing a solution is referred to as problem solving.",
                            Duration = 1.5,
                            Instructor = "Learn Vern",
                            Title = "Problem Solving"
                        });
                });

            modelBuilder.Entity("OnlineCourseManagement.Domain.CourseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("CourseCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Technical Skills",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5465),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5478)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Soft Skills",
                            DateCreated = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5480),
                            DateModified = new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5481)
                        });
                });

            modelBuilder.Entity("OnlineCourseManagement.Domain.Course", b =>
                {
                    b.HasOne("OnlineCourseManagement.Domain.CourseCategory", null)
                        .WithMany("Courses")
                        .HasForeignKey("CourseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineCourseManagement.Domain.CourseCategory", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
