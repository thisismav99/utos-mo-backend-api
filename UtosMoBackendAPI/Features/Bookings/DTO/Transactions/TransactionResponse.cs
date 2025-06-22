namespace UtosMoBackendAPI.Features.Bookings.DTO.Transactions
{
    public class TransactionResponse
    {
        public Guid ID { get; set; }

        public required string TransactionNo { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CompletedDate { get; set; }

        public Guid BookingID { get; set; }

        public bool IsActive { get; set; }
    }
}
