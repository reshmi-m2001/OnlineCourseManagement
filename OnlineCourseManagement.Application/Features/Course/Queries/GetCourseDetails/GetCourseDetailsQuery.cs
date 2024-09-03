using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Queries.GetCourseDetails
{
    public record GetCourseDetailsQuery(Guid id):IRequest<CourseDetailsDTO>;
  
}
