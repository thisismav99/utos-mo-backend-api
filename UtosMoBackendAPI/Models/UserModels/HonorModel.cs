namespace UtosMoBackendAPI.Models.UserModels
{
    public class HonorModel : BaseModel
    {
        public required string Honor { get; set; }

        public DateTime AwardDate { get; set; }
    }
}
