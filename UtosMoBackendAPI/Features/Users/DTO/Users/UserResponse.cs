namespace UtosMoBackendAPI.Features.Users.DTO.Users
{
    public class UserResponse
    {
        public Guid ID { get; set; }

        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set;}

        public string? ContactNumber { get; set; }

        public string? SocialMediaLink { get; set; }

        public bool IsVerified { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
