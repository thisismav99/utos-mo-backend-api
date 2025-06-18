namespace UtosMoBackendAPI.Models.UserModels
{
    public class EducationModel : BaseModel
    {
        public required string SchoolName { get; set; }

        public required string Course { get; set; }

        public double GPA { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool HasGraduated { get; set; }

        public Guid UserID { get; set; }
    }
}
