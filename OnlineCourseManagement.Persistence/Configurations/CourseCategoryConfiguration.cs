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
    public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
    {
        public void Configure(EntityTypeBuilder<CourseCategory> builder)
        {
            //Seed data for CourseCategory

            builder.HasData(

                       new CourseCategory
                       {

                           Id = 1,
                           CategoryName = "Technical Skills",
                           DateCreated = DateTime.Now,
                           DateModified = DateTime.Now,

                       },
                     new CourseCategory
                     {
                         Id = 2,
                         CategoryName = "Soft Skills",
                         DateCreated = DateTime.Now,
                         DateModified = DateTime.Now,
                     }
            );

            //Database level restriction different from Fluid Validation stopping before it gets to database.

            builder.Property(q => q.CategoryName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

