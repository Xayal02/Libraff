using Microsoft.Extensions.DependencyInjection;

namespace Libraff.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            });

            return services;
        }
    }
}
