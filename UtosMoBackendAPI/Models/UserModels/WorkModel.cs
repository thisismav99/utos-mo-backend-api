using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class WorkModel : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public required string Title { get; set; }

        [Required]
        [Range(0, 100)]
        public int YearsExperience { get; set; }

        public bool IsCredited { get; set; }

        public Guid UserID { get; set; }

        public UserModel? User { get; set; }

        public List<IndustryModel>? Industries { get; set; }
    }
}
