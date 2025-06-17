using StudentManagementSystem.Application;
using StudentManagementSystem.Infrastructure;

namespace Student_Management_System_API
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddAPIDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            return services;
        }
    }
}
