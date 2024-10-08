﻿using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Options;
using OnlineCourseManagement.Application.Contracts.Logging;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly IAppLogger<UpdateCourseCommandHandler> _logger;

        public UpdateCourseCommandHandler(IMapper mapper , ICourseRepository courseRepository, ICourseCategoryRepository courseCategoryRepository,IAppLogger<UpdateCourseCommandHandler> logger)
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
            this._courseCategoryRepository = courseCategoryRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {


            //Validate incoming Data
            var validator = new UpdateCourseCommandValidator(_courseRepository);

            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation errors in update request for {0} -{1} ", nameof(Course), request.Id);
                throw new BadRequestException("Invalid course", validationResult);
            }
           /* // Ensure the CategoryId exists in the CourseCategory table
            var categoryExists = await _courseCategoryRepository.ExistsAsync(request.CategoryId);
            if (!categoryExists)
            {
                throw new NotFoundException("CourseCategory", request.CategoryId);
            }
*/
            //convert to DTO objects
            var courseToUpdate = _mapper.Map<Domain.Course>(request);

            //Update database
            await _courseRepository.UpdateAsync(courseToUpdate);

            //return unit value
            return Unit.Value;
        }
    }
}
