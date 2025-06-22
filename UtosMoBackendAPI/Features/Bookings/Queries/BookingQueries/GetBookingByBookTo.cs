using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Bookings;
using UtosMoBackendAPI.Features.Bookings.Services.BookingService;

namespace UtosMoBackendAPI.Features.Bookings.Queries.BookingQueries
{
    public record class GetBookingByBookToQuery(Guid BookTo) : IRequest<Result<List<BookingResponse>>>;

    public class GetBookingByBookToHandler : IRequestHandler<GetBookingByBookToQuery, Result<List<BookingResponse>>>
    {
        #region Variable
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public GetBookingByBookToHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Method
        public async Task<Result<List<BookingResponse>>> Handle(GetBookingByBookToQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingService.GetBookingByBookTo(request.BookTo);
            List<BookingResponse> bookingDTO = booking.Adapt<List<BookingResponse>>();

            return bookingDTO;
        }
        #endregion
    }
}
