namespace UtosMoBackendAPI.Models.SalaryModels
{
    public class SalaryModel : BaseModel
    {
        public decimal Salary { get; set; }

        public required string Currency { get; set; }

        public Guid UserID { get; set; }
    }
}
