using Core.Contracts;
using Core.Services;
using Infrastructure.AplicationDbContext;
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
            });
            services.AddScoped<ICustomer, Customer>();
            return services;
        }
    }
}
