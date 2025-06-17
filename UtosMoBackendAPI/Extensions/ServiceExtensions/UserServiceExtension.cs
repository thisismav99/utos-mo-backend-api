using UtosMoBackendAPI.Features.Users.Services.UserServices;

namespace UtosMoBackendAPI.Extensions.ServiceExtensions
{
    public static class UserServiceExtension
    {
        public static void RegisterUserService(this IServiceCollection services)
        {
            RegisterService(services);
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
