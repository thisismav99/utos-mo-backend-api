using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Contexts;

namespace UtosMoBackendAPI.Extensions.ContextExtensions
{
    public static class UserDbContextExtension
    {
        public static void RegisterUserDbContext(this IServiceCollection services, string connectionString)
        {
            RegisterDatabase(services, connectionString);
        }

        private static void RegisterDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
