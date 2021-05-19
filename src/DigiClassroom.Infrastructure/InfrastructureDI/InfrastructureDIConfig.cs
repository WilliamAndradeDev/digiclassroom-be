using DigiClassroom.Infrastructure.DBConfig;
using DigiClassroom.Infrastructure.Repositories.ClassroomRp;
using DigiClassroom.Infrastructure.Repositories.UserRp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigiClassroom.Infrastructure.InfrastructureDI
{
    public static class InfrastructureDIConfig
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string connectionUrl)
        {
            services.AddDbContext<DigiClassroomContext>
                (options => options.UseNpgsql(connectionUrl));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();

            return services;
        }
    }
}
