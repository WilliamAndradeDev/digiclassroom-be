using DigiClassroom.Infrastructure.DBConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigiClassroom.Infrastructure.InfrastructureDependencyInjection
{
    public static class InfrastructureServiceCollectionExtension
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string connectionUrl)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DigiClassroomContext>
                (options => options.UseNpgsql(connectionUrl));

            return services;
        }
    }
}
