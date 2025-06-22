using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.Services.BookingService;

namespace UtosMoBackendAPI.Features.Bookings.Commands.BookingCommands
{
    public record class DeleteBookingCommand(Guid BookingId) : IRequest<Result<string>>;

    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, Result<string>>
    {
        #region Variable
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public DeleteBookingHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var deleteBooking = await _bookingService.DeleteBooking(request.BookingId);

            return deleteBooking;
        }
        #endregion
    }
}
