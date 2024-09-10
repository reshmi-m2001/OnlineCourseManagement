using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Domain;
using OnlineCourseManagement.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Persistence.Repositories
{
    public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(ConnectionDatabaseContext connectionDatabaseContext) : base(connectionDatabaseContext)
        {
        }

        public async Task<bool> IsCourseCategoryUnique(string courseCategoryName)
        {
            return await _connectionDatabaseContext.CourseCategories.AnyAsync(q => q.CategoryName == courseCategoryName);
        }
    }
}
