using AutoMapper;
using OnlineCourseManagement.Application.Features.Course.Queries.GetAllCourses;
using OnlineCourseManagement.Application.Features.Course.Queries.GetCourseDetails;
using OnlineCourseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.MappingProfiles
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<Course, CourseDetailsDTO>();
        }

    }
}
