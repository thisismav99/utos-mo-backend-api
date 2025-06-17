namespace UtosMoBackendAPI.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
