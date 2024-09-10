using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using OnlineCourseManagement.Application.Contracts.Logging;
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
        private readonly IAppLogger<GetCourseCategoriesQueryHandler> _logger;

        public GetCourseCategoriesQueryHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,IAppLogger<GetCourseCategoriesQueryHandler> logger)
        {

            this._mapper = mapper;
            this._courseCategoryRepository = courseCategoryRepository;
            this._logger = logger;
        }

        public async Task<List<CourseCategoryDTO>> Handle(GetCourseCategoriesQuery request, CancellationToken cancellationToken)
        {
           

            //Query the Database
            var courseCategories = await _courseCategoryRepository.GetAsync();

            // Convert data objects to DTO objects

            var data = _mapper.Map<List<CourseCategoryDTO>>(courseCategories);

            //return List of DTO objects
            _logger.LogInformation("Course Categories were retrived successfully");
            return data;

        }
    }
}
