using AutoMapper;
using OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetAllCourseCategory;
using OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetCourseCategoryDetails;
using OnlineCourseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.MappingProfiles
{
    public class CourseCategoryProfile : Profile
    {

        public CourseCategoryProfile()
        { 
            CreateMap<CourseCategoryDTO , CourseCategory>().ReverseMap();
            CreateMap<CourseCategory, CourseCategoryDetailsDTO>();
        }


    }
}
