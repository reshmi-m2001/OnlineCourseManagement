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
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(IMapper mapper,ICourseRepository courseRepository) 
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {


            //Validate incoming data
            var validator = new CreateCourseCommandValidator(_courseRepository);

            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Course Category", validationResult);
            }

            var courseToCreate= _mapper.Map<Domain.Course>(request);
            await _courseRepository.CreateAsync(courseToCreate);

            return courseToCreate.Id;
        }
    }
}
