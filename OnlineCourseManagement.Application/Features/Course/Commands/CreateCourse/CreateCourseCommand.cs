using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.CreateCourse
{
    public class CreateCourseCommand:IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Duration { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    /*    public string CategoryName { get; set; } = string.Empty;*/
        public string CourseLink { get; set; } = string.Empty;

    }
}
