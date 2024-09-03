using AutoMapper;
using MediatR;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetCourseCategoryDetails
{
    public class GetCourseCategoryDetailsQueryHandler : IRequestHandler<GetCourseCategoryDetailsQuery, CourseCategoryDetailsDTO>

    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public GetCourseCategoryDetailsQueryHandler(IMapper mapper , ICourseCategoryRepository courseCategoryRepository)
        {
            this._mapper = mapper;
            this._courseCategoryRepository = courseCategoryRepository;
        }


        public async Task<CourseCategoryDetailsDTO> Handle(GetCourseCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            

            //Query the Database
            var courseCategory = await _courseCategoryRepository.GetByIdAsync(request.id);

            //Verify that the record Exists
            if (courseCategory == null)
                throw new NotFoundException(nameof(courseCategory), request.id);
            //convert data objects into DTO object

            var data = _mapper.Map<CourseCategoryDetailsDTO>(courseCategory);

            // return DTO object
            return data;
        }
    }
}
