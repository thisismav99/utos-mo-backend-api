namespace UtosMoBackendAPI.Features.Bookings.DTO.Transactions
{
    public class UpdateTransactionRequest
    {
        public bool IsCompleted { get; set; }

        public DateTime CompletedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
