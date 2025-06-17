namespace UtosMoBackendAPI.Models.TransactionModels
{
    public class TransactionModel : BaseModel
    {
        public bool IsCompleted { get; set; }

        public DateTime CompletedDate { get; set; }

        public Guid BookingID { get; set; }
    }
}
