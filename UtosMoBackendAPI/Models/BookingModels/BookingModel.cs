namespace UtosMoBackendAPI.Models.BookingModels
{
    public class BookingModel : BaseModel
    {
        public Guid BookBy { get; set; }

        public Guid BookTo { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
