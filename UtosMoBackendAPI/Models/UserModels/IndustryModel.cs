using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class IndustryModel : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public required string Industry { get; set; }

        public List<WorkModel>? Works { get; set; }
    }
}
