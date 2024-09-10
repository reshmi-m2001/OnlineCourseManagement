using AutoMapper;
using MediatR;
using OnlineCourseManagement.Application.Contracts.Logging;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.UpdateCourseCategory
{
    public class UpdateCourseCategoryCommandHandler : IRequestHandler<UpdateCourseCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly IAppLogger<UpdateCourseCategoryCommandHandler> _logger;

        public UpdateCourseCategoryCommandHandler(IMapper mapper,ICourseCategoryRepository courseCategoryRepository,IAppLogger<UpdateCourseCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._courseCategoryRepository = courseCategoryRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateCourseCategoryCommandValidator(_courseCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation errors in update request for {0} -{1} ", nameof(CourseCategory),request.Id);
                throw new BadRequestException("Invalid CourseCategory", validationResult);
            }
            //Convert to Domanin object
            var courseCategoryToUpdate = _mapper.Map<Domain.CourseCategory>(request);
            //Upadte Database 
            await _courseCategoryRepository.UpdateAsync(courseCategoryToUpdate);
            //Return Unit Value
            return Unit.Value;


        }
    }
}
