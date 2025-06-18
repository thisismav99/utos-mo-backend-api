namespace UtosMoBackendAPI.Features.Reviews.DTO.Reviews
{
    public class AddReviewRequest
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public int Rating { get; set; }

        public Guid UserID { get; set; }
    }
}
