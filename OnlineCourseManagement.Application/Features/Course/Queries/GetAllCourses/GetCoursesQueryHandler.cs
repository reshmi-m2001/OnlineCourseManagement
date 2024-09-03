using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetAllCourseCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Queries.GetAllCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
        }
        public async Task<List<CourseDTO>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            


            //Query the Database
            var courses = await _courseRepository.GetAsync();

            // Convert data objects to DTO objects

            var data = _mapper.Map<List<CourseDTO>>(courses);

            //return List of DTO objects

            return data;
        }
    }
}
