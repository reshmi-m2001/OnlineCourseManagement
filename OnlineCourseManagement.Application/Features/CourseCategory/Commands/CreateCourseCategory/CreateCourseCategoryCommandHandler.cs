using AutoMapper;
using MediatR;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.CreateCourseCategory
{
    public class CreateCourseCategoryCommandHandler : IRequestHandler<CreateCourseCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryReopsitory;

        public CreateCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryReopsitory)
        {
            this._mapper = mapper;
            this._courseCategoryReopsitory = courseCategoryReopsitory;
        }
        public async Task<int> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
        {


            //Validate the incoming data
            var validator = new CreateCourseCategoryCommandValidator(_courseCategoryReopsitory);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Course Category", validationResult);
            }

            //Convert to domain entity object
            var courseCategoryToCreate = _mapper.Map<Domain.CourseCategory>(request);

            //Add to Database
            await _courseCategoryReopsitory.CreateAsync(courseCategoryToCreate);

            //Return record id
            return courseCategoryToCreate.Id;
           
        }
    }
}
