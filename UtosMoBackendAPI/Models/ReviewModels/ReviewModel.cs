using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.ReviewModels
{
    public class ReviewModel : BaseModel
    {
        [Required]
        [MaxLength(60)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Description { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public Guid UserID { get; set; }
    }
}
