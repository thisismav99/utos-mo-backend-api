namespace UtosMoBackendAPI.Features.Bookings.DTO.Bookings
{
    public class AddBookingRequest
    {
        public Guid BookBy { get; set; }

        public Guid BookTo { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
