using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.DeleteCourseCategory
{
    public class DeleteCourseCategoryCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
