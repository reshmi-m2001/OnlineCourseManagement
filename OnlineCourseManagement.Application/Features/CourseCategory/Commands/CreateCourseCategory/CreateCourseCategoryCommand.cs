using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.CreateCourseCategory
{
    public class CreateCourseCategoryCommand :IRequest<int>
    {
        public string CategoryName { get; set; } = string.Empty;
       
    }
}
