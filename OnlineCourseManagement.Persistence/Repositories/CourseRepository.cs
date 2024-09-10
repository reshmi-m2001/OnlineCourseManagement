using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Domain;
using OnlineCourseManagement.Persistence.DatabaseContext;

namespace OnlineCourseManagement.Persistence.Repositories
{
    public class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ConnectionDatabaseContext connectionDatabaseContext) : base(connectionDatabaseContext)
        {
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _connectionDatabaseContext.CourseCategories.AnyAsync(c => c.Id==categoryId);
            
        }
    }
}
