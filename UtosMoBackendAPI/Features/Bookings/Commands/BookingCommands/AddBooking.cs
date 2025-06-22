using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Bookings;
using UtosMoBackendAPI.Features.Bookings.Services.BookingService;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Features.Bookings.Commands.BookingCommands
{
    public record class AddBookingCommand(AddBookingRequest AddBookingRequest) : IRequest<Result<BookingResponse>>;

    public class AddBookingHandler : IRequestHandler<AddBookingCommand, Result<BookingResponse>>
    {
        #region Variable
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public AddBookingHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Method
        public async Task<Result<BookingResponse>> Handle(AddBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new BookingModel()
            {
                BookBy = request.AddBookingRequest.BookBy,
                BookTo = request.AddBookingRequest.BookTo,
                BookingDate = request.AddBookingRequest.BookingDate,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            var addBooking = await _bookingService.AddBooking(booking);

            if (addBooking.IsSuccess)
            {
                BookingResponse bookingDTO = addBooking.Value.Adapt<BookingResponse>();

                return Result.Success(bookingDTO);
            }

            return Result.Failure<BookingResponse>(addBooking.Error);
        }
        #endregion
    }
}
