using DigiClassroom.ApplicationCore.Services.AutheticationSv;
using DigiClassroom.ApplicationCore.Services.ClassroomSv;
using DigiClassroom.ApplicationCore.Services.UserSv;
using DigiClassroom.ApplicationCore.Services.UtilSv.PasswordManager;
using Microsoft.Extensions.DependencyInjection;

namespace DigiClassroom.ApplicationCore.ApplicationCoreDI
{
    public static class ApplicationCoreDIConfig
    {
        public static IServiceCollection RegisterApplicationCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPasswordManager, PasswordMngBCrypt>();
            return services;
        }
    }
}
