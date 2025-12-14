using Libraff.Api.Jobs;
using Libraff.Application.Extensions;
using Libraff.Domain.Extensions;
using Libraff.Infrastructure.Extensions;

namespace Libraff.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddDomainServices();

            builder.Services.AddOpenApi();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.MapControllers();


            app.Run();
        }
    }
}
