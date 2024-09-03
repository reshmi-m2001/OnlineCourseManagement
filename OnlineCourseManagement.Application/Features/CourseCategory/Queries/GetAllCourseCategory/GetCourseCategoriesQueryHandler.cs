using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using OnlineCourseManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetAllCourseCategory
{
    public class GetCourseCategoriesQueryHandler : IRequestHandler<GetCourseCategoriesQuery, List<CourseCategoryDTO>>


    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public GetCourseCategoriesQueryHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository)
        {

            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
        }

       

        public async Task<CourseCategoryDTO> Handle(GetCourseCategoriesQuery request, CancellationToken cancellationToken)
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
