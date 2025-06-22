namespace UtosMoBackendAPI.Features.Bookings.DTO.Bookings
{
    public class BookingResponse
    {
        public Guid ID { get; set; }

        public Guid BookBy { get; set; }

        public Guid BookTo { get; set; }

        public DateTime BookingDate { get; set; }

        public bool IsActive { get; set; }
    }
}
