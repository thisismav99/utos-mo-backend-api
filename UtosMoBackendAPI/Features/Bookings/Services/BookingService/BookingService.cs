using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Contexts;
using UtosMoBackendAPI.Features.Bookings.Utilities;
using UtosMoBackendAPI.Models.BookingModels;
using UtosMoBackendAPI.RepositoryManager;

namespace UtosMoBackendAPI.Features.Bookings.Services.BookingService
{
    public class BookingService : IBookingService
    {
        #region Variables
        private readonly IRepository<BookingModel, BookingDbContext> _repository;
        #endregion

        #region Constructor
        public BookingService(IRepository<BookingModel, BookingDbContext> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Method
        public async Task<Result<BookingModel>> AddBooking(BookingModel booking)
        {
            var bookingExists = await _repository.HasMatch(x => x.BookBy == booking.BookBy &&
                                                                x.BookTo == booking.BookTo &&
                                                                x.BookingDate == booking.BookingDate);

            if(bookingExists)
            {
                return Result.Failure<BookingModel>(BookingResultMessage.Exists);
            }

            await _repository.Add(booking);

            return Result.Success(booking);
        }

        public async Task<Result<string>> DeleteBooking(Guid bookingId)
        {
            var booking = await _repository.GetById(bookingId);

            if(booking is not null)
            {
                await _repository.Delete(booking);

                return Result.Success(BookingResultMessage.Removed);
            }

            return Result.Failure<string>(BookingResultMessage.NotFound);
        }

        public async Task<List<BookingModel>?> GetBookingByBookBy(Guid bookBy)
        {
            return await _repository.GetAllBy(x => x.BookBy == bookBy);
        }

        public async Task<List<BookingModel>?> GetBookingByBookTo(Guid bookTo)
        {
            return await _repository.GetAllBy(x => x.BookTo == bookTo);
        }

        public async Task<Result<BookingModel?>> GetBookingById(Guid bookingId)
        {
            var booking = await _repository.GetById(bookingId);

            if(booking is not null)
            {
                return Result.Success<BookingModel?>(booking);
            }
            else
            {
                return Result.Failure<BookingModel?>(BookingResultMessage.NotFound);
            }
        }

        public async Task<Result<string>> UpdateBooking(BookingModel booking)
        {
            var isExactBooking = await _repository.HasMatch(x => x.ID == booking.ID &&
                                                                 x.BookBy == booking.BookBy &&
                                                                 x.BookTo == booking.BookTo &&
                                                                 x.BookingDate == booking.BookingDate &&
                                                                 x.IsActive == booking.IsActive);

            if(isExactBooking)
            {
                return Result.Failure<string>(BookingResultMessage.NoChanges);
            }

            await _repository.Update(booking);

            return Result.Success(BookingResultMessage.Updated);
        }
        #endregion
    }
}
