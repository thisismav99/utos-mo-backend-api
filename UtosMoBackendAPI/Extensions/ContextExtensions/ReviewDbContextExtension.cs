using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Contexts;

namespace UtosMoBackendAPI.Extensions.ContextExtensions
{
    public static class ReviewDbContextExtension
    {
        public static void RegisterReviewDbContext(this IServiceCollection services, string connectionString)
        {
            RegisterDatabase(services, connectionString);
        }

        private static void RegisterDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ReviewDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
