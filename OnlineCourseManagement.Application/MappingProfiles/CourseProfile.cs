using AutoMapper;
using OnlineCourseManagement.Application.Features.Course.Commands.CreateCourse;
using OnlineCourseManagement.Application.Features.Course.Commands.UpdateCourse;
using OnlineCourseManagement.Application.Features.Course.Queries.GetAllCourses;
using OnlineCourseManagement.Application.Features.Course.Queries.GetCourseDetails;
using OnlineCourseManagement.Application.Features.CourseCategory.Commands.CreateCourseCategory;
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

            //CreateMap<CreateCourseCommand, Course>();
            // Create mapping between CreateCourseCommand and Course
            CreateMap<CreateCourseCommand, Domain.Course>();
            CreateMap<UpdateCourseCommand, Domain.Course>();
        }

    }
}
