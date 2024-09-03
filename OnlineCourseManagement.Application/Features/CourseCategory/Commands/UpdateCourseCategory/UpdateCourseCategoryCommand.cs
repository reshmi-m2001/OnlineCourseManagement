using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.UpdateCourseCategory
{
    public class UpdateCourseCategoryCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
