using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.SalaryModels
{
    public class SalaryModel : BaseModel
    {
        [Required]
        public decimal Salary { get; set; }

        [Required]
        [MaxLength(10)]
        public required string Currency { get; set; }

        public Guid UserID { get; set; }
    }
}
