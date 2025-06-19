using UtosMoBackendAPI.Features.Works.Services.IndustryServices;
using UtosMoBackendAPI.Features.Works.Services.WorkServices;

namespace UtosMoBackendAPI.Extensions.ServiceExtensions
{
    public static class WorkServiceExtension
    {
        public static void RegisterWorkService(this IServiceCollection services)
        {
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IIndustryService, IndustryService>();
        }
    }
}
