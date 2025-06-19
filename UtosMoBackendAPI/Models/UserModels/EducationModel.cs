using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class EducationModel : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public required string SchoolName { get; set; }

        [Required]
        [MaxLength(60)]
        public required string Course { get; set; }

        [Required]
        public double GPA { get; set; }

        [Required]
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool HasGraduated { get; set; }

        public Guid UserID { get; set; }

        public required UserModel User { get; set; }

        public HonorModel? HonorID { get; set; }
    }
}
