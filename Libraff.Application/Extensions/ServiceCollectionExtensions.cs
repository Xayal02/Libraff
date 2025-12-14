using Libraff.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using static CSharpFunctionalExtensions.Result;

namespace Libraff.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
                configuration.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));

            });




            return services;
        }
    }
}
