using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommand:IRequest<Unit>

    {
        public int Id { get; set; }
    }
}
