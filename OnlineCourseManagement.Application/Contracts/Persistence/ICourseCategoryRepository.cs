using OnlineCourseManagement.Domain;

namespace OnlineCourseManagement.Application.Contracts.Persistence
{
    public interface ICourseCategoryRepository : IGenericRepository<CourseCategory>

    { 
        Task<bool> IsCourseCategoryUnique(string name);
    }

}
