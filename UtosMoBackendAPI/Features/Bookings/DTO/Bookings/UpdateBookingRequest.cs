namespace UtosMoBackendAPI.Features.Bookings.DTO.Bookings
{
    public class UpdateBookingRequest
    {
        public Guid BookBy { get; set; }

        public Guid BookTo { get; set; }

        public DateTime BookingDate { get; set; }

        public bool IsActive { get; set; }
    }
}
