using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Bookings;
using UtosMoBackendAPI.Features.Bookings.Services.BookingService;

namespace UtosMoBackendAPI.Features.Bookings.Queries.BookingQueries
{
    public record class GetBookingByIdQuery(Guid BookingId) : IRequest<Result<BookingResponse>>;

    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, Result<BookingResponse>>
    {
        #region Variable
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public GetBookingByIdHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Method
        public async Task<Result<BookingResponse>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await _bookingService.GetBookingById(request.BookingId);

            if (booking.IsSuccess)
            {
                BookingResponse bookingDTO = booking.Value.Adapt<BookingResponse>();

                return Result.Success(bookingDTO);
            }

            return Result.Failure<BookingResponse>(booking.Error);
        }
        #endregion
    }
}
