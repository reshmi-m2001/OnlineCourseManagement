using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseManagement.Application.Contracts.Persistence;
using OnlineCourseManagement.Persistence.DatabaseContext;
using OnlineCourseManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this ServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ConnectionDatabaseContext>(options =>
            {

                options.UseMySQL(configuration.GetConnectionString("CourseConnectionString"));


            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            return services;
        }
    }
}
