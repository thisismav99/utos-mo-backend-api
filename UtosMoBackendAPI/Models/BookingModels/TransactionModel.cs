using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.BookingModels
{
    public class TransactionModel : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public required string TransactionNo { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CompletedDate { get; set; }

        public Guid BookingID { get; set; }

        public BookingModel? Booking { get; set; }
    }
}
