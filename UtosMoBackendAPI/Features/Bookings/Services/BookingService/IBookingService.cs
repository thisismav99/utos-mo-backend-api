using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Features.Bookings.Services.BookingService
{
    public interface IBookingService
    {
        Task<Result<BookingModel>> AddBooking(BookingModel booking);
        Task<Result<string>> DeleteBooking(Guid bookingId);
        Task<Result<string>> UpdateBooking(BookingModel booking);
        Task<Result<BookingModel?>> GetBookingById(Guid bookingId);
        Task<List<BookingModel>?> GetBookingByBookBy(Guid bookBy);
        Task<List<BookingModel>?> GetBookingByBookTo(Guid bookTo);
    }
}
