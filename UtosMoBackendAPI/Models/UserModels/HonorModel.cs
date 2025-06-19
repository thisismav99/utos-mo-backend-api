using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class HonorModel : BaseModel
    {
        [Required]
        [MaxLength(60)]
        public required string Honor { get; set; }

        public DateTime AwardDate { get; set; }

        public Guid EducationID { get; set; }

        public required EducationModel Education { get; set; }
    }
}
