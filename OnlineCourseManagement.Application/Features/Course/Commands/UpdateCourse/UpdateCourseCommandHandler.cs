using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Options;
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

        public UpdateCourseCommandHandler(IMapper mapper , ICourseRepository courseRepository)
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {


            //Validate incoming Data
            var validator = new UpdateCourseCommandValidator(_courseRepository);

            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid course", validationResult);
            }

            //convert to DTO objects
            var courseToUpdate = _mapper.Map<Domain.Course>(request);

            //Update database
            await _courseRepository.UpdateAsync(courseToUpdate);

            //return unit value
            return Unit.Value;
        }
    }
}
