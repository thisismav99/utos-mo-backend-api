using UtosMoBackendAPI.Features.Bookings.Services.BookingService;
using UtosMoBackendAPI.Features.Bookings.Services.TransactionService;

namespace UtosMoBackendAPI.Extensions.ServiceExtensions
{
    public static class BookingServiceExtension
    {
        public static void RegisterBookingServices(this IServiceCollection services)
        {
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
