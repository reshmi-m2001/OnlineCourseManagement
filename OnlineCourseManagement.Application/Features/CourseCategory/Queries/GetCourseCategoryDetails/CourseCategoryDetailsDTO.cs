using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetCourseCategoryDetails
{
    public class CourseCategoryDetailsDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
