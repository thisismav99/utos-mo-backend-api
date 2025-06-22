namespace UtosMoBackendAPI.Features.Bookings.DTO.Transactions
{
    public class AddTransactionRequest
    {
        public bool IsCompleted { get; set; }

        public DateTime CompletedDate { get; set; }
    }
}
