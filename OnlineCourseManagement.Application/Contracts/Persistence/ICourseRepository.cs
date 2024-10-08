﻿using OnlineCourseManagement.Domain;

namespace OnlineCourseManagement.Application.Contracts.Persistence
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<bool> CategoryExistsAsync(int categoryId);

    }
}
