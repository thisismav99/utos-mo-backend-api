using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class AddressModel : BaseModel
    {
        [MaxLength(5)]
        public string? LotNo { get; set; }

        [MaxLength(60)]
        public string? Street { get; set; }

        [Required]
        [MaxLength(60)]
        public required string Barangay { get; set; }

        [Required]
        [MaxLength(60)]
        public required string City { get; set; }

        [Required]
        [MaxLength(60)]
        public required string Region { get; set; }

        [Required]
        [MaxLength(60)]
        public required string Country { get; set; }

        public bool IsPresentAddress { get; set; }

        public bool IsPermanent { get; set; }

        public Guid UserID { get; set; }

        public UserModel? User { get; set; }
    }
}
