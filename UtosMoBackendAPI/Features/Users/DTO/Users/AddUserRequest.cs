namespace UtosMoBackendAPI.Features.Users.DTO.Users
{
    public class AddUserRequest
    {
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public required string LastName { get; set; }

        public string? ContactNumber { get; set; }

        public string? SocialMediaLink { get; set; }
    }
}
