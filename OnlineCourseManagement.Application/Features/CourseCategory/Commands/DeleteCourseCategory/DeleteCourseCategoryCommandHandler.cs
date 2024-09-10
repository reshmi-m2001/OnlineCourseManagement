using MediatR;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.DeleteCourseCategory
{
    public class DeleteCourseCategoryCommandHandler : IRequestHandler<DeleteCourseCategoryCommand, Unit>
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public DeleteCourseCategoryCommandHandler(ICourseCategoryRepository courseCategoryRepository)
        {
            this._courseCategoryRepository = courseCategoryRepository;
        }
        public async Task<Unit> Handle(DeleteCourseCategoryCommand request, CancellationToken cancellationToken)
        {
          
          //Retrieve domain entity object
          var courseCategoryToDelete =await _courseCategoryRepository.GetByIdAsync(request.Id);

            // Verify that record exist
            if (courseCategoryToDelete == null)
            
                throw new NotFoundException(nameof(CourseCategory), request.Id)  ;
                
                //Remove from database
                await _courseCategoryRepository.DeleteAsync(courseCategoryToDelete);
            //Return unit
            return Unit.Value;
        }
    }
}
