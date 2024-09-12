using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourseManagement.Application.Contracts.Logging;
using OnlineCourseManagement.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection
            services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;

        }
    }
}
