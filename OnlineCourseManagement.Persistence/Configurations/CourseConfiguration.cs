using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCourseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Generate Guids for the course categories
            var technicalSkillsCategoryId = Guid.NewGuid();
            var softSkillsCategoryId = Guid.NewGuid();
            //Seed data for Course

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Title = "Gemini in Google Drive",
                    Description = "The Gemini in Google Drive course introduces you to Gemini, an AI-powered tool integrated within Google Drive. Learn how to leverage Gemini's capabilities to enhance document management, streamline workflows, and improve collaboration. This course covers everything from setup to advanced features, empowering you to maximize productivity and efficiency using AI-driven insights in Google Drive.",
                    Duration = 1,
                    Instructor = "Google Cloud",
                    CategoryId = technicalSkillsCategoryId,
                    CourseLink = "https://www.cloudskillsboost.google/paths/249/course_templates/1135",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,

                },
                new Course
                {
                    Id = 2,
                    Title = "Communication Skills and Its Types",
                    Description = "In order to succeed in the workplace, it is important that you are able to communicate with others and deliver your point effectively. You should also be able to listen carefully and respond appropriately.",
                    Duration = 1.5,
                    Instructor = "Learn Vern",
                    CategoryId = softSkillsCategoryId,
                    CourseLink = "https://www.learnvern.com/soft-skills-training/introduction-to-communication-skills-and-types",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                },
                 new Course
                 {
                     Id = 3,
                     Title = "Time Management",
                     Description = "Time management skills can be divided into two categories: personal time management and professional time management. Personal time management includes things like prioritizing, goal setting, scheduling, self-discipline, and self-control. Professional time management includes things like planning, organizing, delegation, delegation of tasks, collaboration with co-workers, meeting deadlines.",
                     Duration = 1.5,
                     Instructor = "Learn Vern",
                     CategoryId = softSkillsCategoryId,
                     CourseLink = "https://www.learnvern.com/soft-skills-training/time-management-skills",
                     DateCreated = DateTime.Now,
                     DateModified = DateTime.Now,
                 },
                   new Course
                   {
                       Id =4,
                       Title = "ASP.NET Core 8 Web API in Clean architecture from scratch",
                       Description = "Building an ASP.NET Core 8 Web API using Clean Architecture involves structuring the application into distinct layers: Presentation, Application, Domain, and Infrastructure. The Presentation Layer handles HTTP requests and responses through API controllers, while the Application Layer manages business logic and use cases. The Domain Layer defines core business entities and rules, and the Infrastructure Layer deals with data access and external services. This approach ensures a modular, maintainable, and testable codebase.",
                       Duration = 1.5,
                       Instructor = "YouTube - Fullstack Dev",
                       CategoryId = technicalSkillsCategoryId,
                       CourseLink = "https://www.youtube.com/watch?v=E6sUJWwZLwE",
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now,

                   },
                   new Course
                   {
                       Id = 5,
                       Title = "Problem Solving",
                       Description = "The act of describing a problem, discovering the origin of the problem, identifying, prioritising, and selecting potential solutions for a solution, and implementing a solution is referred to as problem solving.",
                       Duration = 1.5,
                       Instructor = "Learn Vern",
                       CategoryId = softSkillsCategoryId,
                       CourseLink = "https://www.learnvern.com/soft-skills-training/define-problem",
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now,
                   }


                );
        }
    }
}
