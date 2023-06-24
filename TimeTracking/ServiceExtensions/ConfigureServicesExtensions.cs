using Core.Contracts;
using Core.IdentityEntities;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TimeTracking.Web.ServiceExtensions;

public static class ConfigureServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services,
        IConfiguration configuration)
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

        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 3; //Eg: AB12AB (unique characters are A,B,1,2)
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
            .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

        services.AddHttpLogging(options =>
        {
            options.LoggingFields =
                HttpLoggingFields.RequestProperties | HttpLoggingFields.ResponsePropertiesAndHeaders;
        });
        return services;
    }
}