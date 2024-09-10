using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetCourseCategoryDetails
{
    public record GetCourseCategoryDetailsQuery(int id) : IRequest<CourseCategoryDetailsDTO>;
    
    
}
