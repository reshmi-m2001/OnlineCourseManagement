using FluentValidation;
using OnlineCourseManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.CreateCourseCategory
{
    public class CreateCourseCategoryCommandValidator:AbstractValidator<CreateCourseCategoryCommand>
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public CreateCourseCategoryCommandValidator(ICourseCategoryRepository courseCategoryRepository)
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{CategoryName} is required")
                .NotNull()
                .MaximumLength(20).WithMessage("{CategoryName} should must be fewer than 20 characters");

            RuleFor(q => q)
                .MustAsync(CourseCategoryNameUnique)
                .WithMessage("The particular Course Category already exists.");



            this._courseCategoryRepository = courseCategoryRepository;
        }

        private Task<bool> CourseCategoryNameUnique(CreateCourseCategoryCommand command, CancellationToken token)
        {
            return _courseCategoryRepository.IsCourseCategoryUnique(command.CategoryName);
        }
    }
}
