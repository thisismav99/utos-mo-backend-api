using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Contexts;

namespace UtosMoBackendAPI.Extensions.ContextExtensions
{
    public static class WorkDbContextExtension
    {
        public static void RegisterWorkDbContext(this IServiceCollection services, string connectionString)
        {
            RegisterDatabase(services, connectionString);
        }

        private static void RegisterDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<WorkDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
