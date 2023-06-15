using Core.Contracts;
using Infrastructure.AplicationDbContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TimeTracking.Web.ServiceExtensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(b => b.MigrationsAssembly("Infrastructure"));
            });
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<IProjectName, ProjectNameRepository>();
            services.AddScoped<IProjectOwner, ProjectOwnerRepository>();
            services.AddScoped<ITaskType, TaskTypeRepository>();
            services.AddScoped<ITimeTracking, TimeTrackingRepository>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
