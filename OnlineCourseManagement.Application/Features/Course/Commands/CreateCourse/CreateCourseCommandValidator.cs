using FluentValidation;
using OnlineCourseManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Commands.CreateCourse
{
    public class CreateCourseCommandValidator:AbstractValidator<CreateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandValidator(ICourseRepository courseRepository)
        {

            // Title validation
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("{Title} is required.")
                .MaximumLength(100).WithMessage("{Title} must not exceed 100 characters.");

            // Description validation
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("{Description} is required.")
                .MaximumLength(500).WithMessage("{Description} must not exceed 500 characters.");

            // Duration validation
            RuleFor(c => c.Duration)
                .GreaterThan(0).WithMessage("{Duration} must be greater than 0.");

            // Instructor validation
            RuleFor(c => c.Instructor)
                .NotEmpty().WithMessage("{Instructor} is required.")
                .MaximumLength(100).WithMessage("{Instructor} must not exceed 100 characters.");

            // CategoryId validation
            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("{CategoryId} is required.")
                .MustAsync(CategoryExists).WithMessage("The specified {CategoryId} does not exist.");

            // CourseLink validation
            RuleFor(c => c.CourseLink)
                .NotEmpty().WithMessage("{CourseLink} is required.")
                .Must(LinkIsValid).WithMessage("{CourseLink} is not a valid URL.");
            this._courseRepository = courseRepository;
        }

        // Ensure the Category exists
        private async Task<bool> CategoryExists(int categoryId, CancellationToken token)
        {
            return await _courseRepository.CategoryExistsAsync(categoryId);
        }

        // Check if the link is valid
        private bool LinkIsValid(string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out var _);
        }
    }
}

