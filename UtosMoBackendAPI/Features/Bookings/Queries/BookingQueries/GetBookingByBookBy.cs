using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Bookings;
using UtosMoBackendAPI.Features.Bookings.Services.BookingService;

namespace UtosMoBackendAPI.Features.Bookings.Queries.BookingQueries
{
    public record class GetBookingByBookByQuery(Guid BookBy) : IRequest<Result<List<BookingResponse>>>;

    public class GetBookingByBookByHandler : IRequestHandler<GetBookingByBookByQuery, Result<List<BookingResponse>>>
    {
        #region Variable
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public GetBookingByBookByHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Method
        public async Task<Result<List<BookingResponse>>> Handle(GetBookingByBookByQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingService.GetBookingByBookBy(request.BookBy);
            List<BookingResponse> bookingDTO = booking.Adapt<List<BookingResponse>>();
            
            return bookingDTO;
        }
        #endregion
    }
}
