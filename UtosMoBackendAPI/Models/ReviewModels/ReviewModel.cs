namespace UtosMoBackendAPI.Models.ReviewModels
{
    public class ReviewModel : BaseModel
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public int Rating { get; set; }

        public Guid UserID { get; set; }
    }
}
