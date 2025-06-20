using UtosMoBackendAPI.Features.Users.Services.IndustryServices;
using UtosMoBackendAPI.Features.Users.Services.UserServices;
using UtosMoBackendAPI.Features.Users.Services.WorkServices;

namespace UtosMoBackendAPI.Extensions.ServiceExtensions
{
    public static class UserServiceExtension
    {
        public static void RegisterUserServices(this IServiceCollection services)
        {
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IIndustryService, IndustryService>();
        }
    }
}
