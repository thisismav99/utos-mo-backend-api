namespace UtosMoBackendAPI.Models.WorkModels
{
    public class WorkModel : BaseModel
    {
        public required string Title { get; set; }

        public int YearsExperience { get; set; }

        public bool IsCredited { get; set; }

        public Guid IndustryID { get; set; }

        public Guid UserID { get; set; }
    }
}
