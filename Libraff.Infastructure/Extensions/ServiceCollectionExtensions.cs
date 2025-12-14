using Hangfire;
using Hangfire.PostgreSql;
using Libraff.Application.Abstractions;
using Libraff.Domain.Repositories;
using Libraff.Infrastructure.Persistence;
using Libraff.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libraff.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPositionLimitRepository, PositionLimitRepository>();
            services.AddScoped<IBookSupplyRepository, BookSupplyRepository>();
            services.AddScoped<IBranchStockRepository, BranchStockRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            string connectionString = (configuration.GetConnectionString("DefaultConnection"))!;

            services.AddDbContext<LibraffDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddHangfire(configuration => configuration
            .UsePostgreSqlStorage(options =>
            options.UseNpgsqlConnection(connectionString)));

            services.AddHangfireServer();


            return services;


        }
    }
}
