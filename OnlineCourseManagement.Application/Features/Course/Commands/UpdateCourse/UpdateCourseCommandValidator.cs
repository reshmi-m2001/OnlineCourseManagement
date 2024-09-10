using FluentValidation;
using OnlineCourseManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandValidator(ICourseRepository courseRepository)
        
            {
                RuleFor(c => c.Title)
                 .NotEmpty().WithMessage("{Title} is required.")
                 .MaximumLength(50).WithMessage("{Title} must be fewer than 50 characters.");

                RuleFor(c => c.Description)
                    .NotEmpty().WithMessage("{Description} is required.")
                    .MaximumLength(200).WithMessage("{Description} must not exceed 200 characters.");

                RuleFor(c => c.Duration)
                    .GreaterThan(0).WithMessage("{Duration} must be greater than 0.");

                RuleFor(c => c.Instructor)
                    .NotEmpty().WithMessage("{Instructor} is required.")
                    .MaximumLength(100).WithMessage("{Instructor} must not exceed 100 characters.");

            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("Course category is required.")
                .MustAsync(CategoryExists).WithMessage("The specified course category does not exist.");

            RuleFor(c => c.CourseLink)
                    .NotEmpty().WithMessage("{CourseLink} is required.")
                    .Must(LinkIsValid).WithMessage("{CourseLink} is not a valid URL.");
                this._courseRepository = courseRepository;
            }


            private async Task<bool> CategoryExists(int categoryId, CancellationToken cancellationToken)
            {
                return await _courseRepository.CategoryExistsAsync(categoryId);
            }

            private bool LinkIsValid(string link)
            {
                return Uri.TryCreate(link, UriKind.Absolute, out var _);
            }

           
        }
    
}
