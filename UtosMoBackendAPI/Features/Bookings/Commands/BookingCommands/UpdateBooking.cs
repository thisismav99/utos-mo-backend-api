using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Bookings;
using UtosMoBackendAPI.Features.Bookings.Services.BookingService;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Features.Bookings.Commands.BookingCommands
{
    public record class UpdateBookingCommand(Guid BookingId, UpdateBookingRequest UpdateBookingRequest) : IRequest<Result<string>>;

    public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, Result<string>>
    {
        #region Variable
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public UpdateBookingHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new BookingModel()
            {
                ID = request.BookingId,
                BookBy = request.UpdateBookingRequest.BookBy,
                BookTo = request.UpdateBookingRequest.BookTo,
                BookingDate = request.UpdateBookingRequest.BookingDate,
                IsActive = request.UpdateBookingRequest.IsActive
            };

            var updateBooking = await _bookingService.UpdateBooking(booking);

            return updateBooking;
        }
        #endregion
    }
}
