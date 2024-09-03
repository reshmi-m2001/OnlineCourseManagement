using AutoMapper;
using MediatR;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetCourseCategoryDetails;
using OnlineCourseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Queries.GetCourseDetails
{
    public class GetCourseDetailsQueryHandler : IRequestHandler<GetCourseDetailsQuery, CourseDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public GetCourseDetailsQueryHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
        }
      
        public async Task<CourseDetailsDTO> Handle(GetCourseDetailsQuery request, CancellationToken cancellationToken)
        {
           

            //Query the database

            var course = await _courseRepository.GetByIdAsync(request.id);

            //Verify that the record Exists
            if (course == null)
                throw new NotFoundException(nameof(course), request.id);

            // convert data objects int DTO objects

            var data = _mapper.Map<CourseDetailsDTO>(course);

            // return DTO objects
            return data;
        }
    }
}
