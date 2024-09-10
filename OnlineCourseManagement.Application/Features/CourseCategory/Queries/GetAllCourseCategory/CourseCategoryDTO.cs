using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetAllCourseCategory
{
    public class CourseCategoryDTO
    {

        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
