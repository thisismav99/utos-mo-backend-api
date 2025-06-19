using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class UserModel : BaseModel
    {
        [Required]
        [MaxLength(60)]
        public required string FirstName { get; set; }

        [MaxLength(60)]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(60)]
        public required string LastName { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? ContactNumber { get; set; }

        [MaxLength(100)]
        public string? SocialMediaLink { get; set; }

        public bool IsVerified { get; set; }

        public List<AddressModel>? Addresses { get; set; }

        public List<EducationModel>? Educations { get; set; }
    }
}
