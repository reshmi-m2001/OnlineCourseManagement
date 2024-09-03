using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetAllCourseCategory
{
    /* public class GetCourseCategoryQuery : IRequest<List<CourseCategoryDTO>>
     {
     }*/
    public record GetCourseCategoriesQuery : IRequest<List<CourseCategoryDTO>>;
}
