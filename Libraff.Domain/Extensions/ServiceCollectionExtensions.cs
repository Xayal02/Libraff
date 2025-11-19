using Libraff.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Libraff.Domain.Extensions
{

    // I am not sure whether it should be here or not
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<EmployeeService>();
            services.AddScoped<BookSupplyService>();
            return services;
        }
    }
}
