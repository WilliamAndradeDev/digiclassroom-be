using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DigiClassroom.ApplicationCore.Services.UserSV;
using DigiClassroom.Infrastructure.InfrastructureDependencyInjection;
using DigiClassroom.Infrastructure.Repositories.UserRp;
using DigiClassroom.Web.SecurityConfig;
using DigiClassroom.Web.SecurityConfig.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DigiClassroom.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.RegisterInfrastructureServices(Configuration.GetConnectionString("digiclassroom-db"));

            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<JwtSecurityTokenHandler>();

            JwtConfig.Secret=Encoding.ASCII.GetBytes(
                                    Configuration.GetValue<string>("JwtConfig:Secret"));
            services.AddAuthentication(auth=>{
                auth.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOpt=>{
                jwtOpt.RequireHttpsMetadata=false;
                jwtOpt.SaveToken=true;
                jwtOpt.TokenValidationParameters= new TokenValidationParameters{
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey= new SymmetricSecurityKey(JwtConfig.Secret),
                    ValidateIssuer=false,
                    ValidateAudience=false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(cors=>cors
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
