using AutoMapper;
using MediatR;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseCategoryRepository _courseCategoryRepository;  // Inject CourseCategoryRepository

        public CreateCourseCommandHandler(IMapper mapper,ICourseRepository courseRepository, ICourseCategoryRepository courseCategoryRepository) 
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
            this._courseCategoryRepository = courseCategoryRepository;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {


            //Validate incoming data
            var validator = new CreateCourseCommandValidator(_courseRepository);

            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Course", validationResult);
            }

            // Ensure the CategoryId exists in the CourseCategory table
            var categoryExists = await _courseRepository.CategoryExistsAsync(request.CategoryId);
            if (!categoryExists)
            {
                throw new NotFoundException("CourseCategory", request.CategoryId);
            }


            // Map the request to the Course domain entity
            var courseToCreate = _mapper.Map<Domain.Course>(request);
            // Add the course to the database
            await _courseRepository.CreateAsync(courseToCreate);

            return courseToCreate.Id;
        }
    }
}
