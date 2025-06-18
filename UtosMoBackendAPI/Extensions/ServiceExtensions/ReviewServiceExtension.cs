using UtosMoBackendAPI.Features.Reviews.Services.ReviewServices;

namespace UtosMoBackendAPI.Extensions.ServiceExtensions
{
    public static class ReviewServiceExtension
    {
        public static void RegisterReviewService(this IServiceCollection services)
        {
            RegisterService(services);
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IReviewService, ReviewService>();
        }
    }
}
