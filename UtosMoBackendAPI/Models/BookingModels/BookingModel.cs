using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.BookingModels
{
    public class BookingModel : BaseModel
    {
        [Required]
        public Guid BookBy { get; set; }

        [Required]
        public Guid BookTo { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
    }
}
