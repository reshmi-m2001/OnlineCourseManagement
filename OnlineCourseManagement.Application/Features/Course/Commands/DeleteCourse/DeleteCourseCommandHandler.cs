using MediatR;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository) 
        {
            this._courseRepository = courseRepository;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
          
            //Retrive the course entity from the database

            var courseToDelete = await _courseRepository.GetByIdAsync(request.Id);

            //Verfying that the course exists

            if (courseToDelete == null)
            
                throw new NotFoundException(nameof(Course), request.Id);
            
                //Remove the course from the database
                await _courseRepository.DeleteAsync(courseToDelete);

            //Return Unit , signaling that the operation was successful
            return Unit.Value;

        }
    }
}
