using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Duration { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public int CourseCategoryId { get; set; }
        /*public string CategoryName { get; set; } = string.Empty;*/
        public string CourseLink { get; set; } = string.Empty;
    }
}
