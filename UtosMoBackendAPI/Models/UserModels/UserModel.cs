namespace UtosMoBackendAPI.Models.UserModels
{
    public class UserModel : BaseModel
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public string? ContactNumber { get; set; }

        public string? SocialMediaLink { get; set; }

        public bool IsVerified { get; set; }

        public List<Guid>? EducationID { get; set; }

        public Guid? AddressID { get; set; }
    }
}
