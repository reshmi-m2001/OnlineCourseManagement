using FluentValidation;
using OnlineCourseManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.CourseCategory.Commands.UpdateCourseCategory
{
    public class UpdateCourseCategoryCommandValidator : AbstractValidator<UpdateCourseCategoryCommand>
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public UpdateCourseCategoryCommandValidator(ICourseCategoryRepository courseCategoryRepository)
        {
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(CourseCategoryMustExist);

            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{CategoryName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{CategoryName} should must be fewer than 50 characters");


            this._courseCategoryRepository = courseCategoryRepository;
        }

        private async Task<bool> CourseCategoryMustExist(int Id, CancellationToken token)
        {
            var courseCategory = await _courseCategoryRepository.GetByIdAsync(Id);
            return courseCategory != null;
        }
    }
}
