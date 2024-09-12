using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCourseManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Duration = table.Column<double>(type: "double", nullable: false),
                    Instructor = table.Column<string>(type: "longtext", nullable: false),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false),
                    CourseLink = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "CategoryName", "DateCreated", "DateModified" },
                values: new object[,]
                {
                    { 1, "Technical Skills", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5465), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5478) },
                    { 2, "Soft Skills", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5480), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(5481) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCategoryId", "CourseLink", "DateCreated", "DateModified", "Description", "Duration", "Instructor", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://www.cloudskillsboost.google/paths/249/course_templates/1135", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6077), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6078), "The Gemini in Google Drive course introduces you to Gemini, an AI-powered tool integrated within Google Drive. Learn how to leverage Gemini's capabilities to enhance document management, streamline workflows, and improve collaboration. This course covers everything from setup to advanced features, empowering you to maximize productivity and efficiency using AI-driven insights in Google Drive.", 1.0, "Google Cloud", "Gemini in Google Drive" },
                    { 2, 2, "https://www.learnvern.com/soft-skills-training/introduction-to-communication-skills-and-types", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6081), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6082), "In order to succeed in the workplace, it is important that you are able to communicate with others and deliver your point effectively. You should also be able to listen carefully and respond appropriately.", 1.5, "Learn Vern", "Communication Skills and Its Types" },
                    { 3, 2, "https://www.learnvern.com/soft-skills-training/time-management-skills", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6084), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6085), "Time management skills can be divided into two categories: personal time management and professional time management. Personal time management includes things like prioritizing, goal setting, scheduling, self-discipline, and self-control. Professional time management includes things like planning, organizing, delegation, delegation of tasks, collaboration with co-workers, meeting deadlines.", 1.5, "Learn Vern", "Time Management" },
                    { 4, 1, "https://www.youtube.com/watch?v=E6sUJWwZLwE", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6088), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6088), "Building an ASP.NET Core 8 Web API using Clean Architecture involves structuring the application into distinct layers: Presentation, Application, Domain, and Infrastructure. The Presentation Layer handles HTTP requests and responses through API controllers, while the Application Layer manages business logic and use cases. The Domain Layer defines core business entities and rules, and the Infrastructure Layer deals with data access and external services. This approach ensures a modular, maintainable, and testable codebase.", 1.5, "YouTube - Fullstack Dev", "ASP.NET Core 8 Web API in Clean architecture from scratch" },
                    { 5, 2, "https://www.learnvern.com/soft-skills-training/define-problem", new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6091), new DateTime(2024, 9, 11, 10, 36, 27, 860, DateTimeKind.Local).AddTicks(6092), "The act of describing a problem, discovering the origin of the problem, identifying, prioritising, and selecting potential solutions for a solution, and implementing a solution is referred to as problem solving.", 1.5, "Learn Vern", "Problem Solving" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseCategories");
        }
    }
}
