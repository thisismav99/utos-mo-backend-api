namespace UtosMoBackendAPI.Features.Reviews.DTO.Reviews
{
    public class ReviewResponse
    {
        public Guid ID { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public int Rating { get; set; }

        public bool IsActive { get; set; }
    }
}
