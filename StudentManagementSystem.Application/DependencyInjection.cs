using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Application.Services;

namespace StudentManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {   
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISubjectService, SubjectService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;
        }
    }
}
