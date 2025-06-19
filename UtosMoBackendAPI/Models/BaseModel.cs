using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models
{
    public class BaseModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
