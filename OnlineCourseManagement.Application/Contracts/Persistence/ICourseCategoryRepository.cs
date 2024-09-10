using OnlineCourseManagement.Domain;

namespace OnlineCourseManagement.Application.Contracts.Persistence
{
    public interface ICourseCategoryRepository : IGenericRepository<CourseCategory>

    {
/*        Task<bool> ExistsAsync(int categoryId);*/

        Task<bool> IsCourseCategoryUnique(string courseCategoryName);
    }

}
