using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UtosMoBackendAPI.Models.UserModels
{
    public class SalaryModel : BaseModel
    {
        [Required]
        [Precision(18,2)]
        public decimal Salary { get; set; }

        [Required]
        [MaxLength(10)]
        public required string Currency { get; set; }

        public Guid UserID { get; set; }

        public UserModel? User { get; set; }
    }
}
