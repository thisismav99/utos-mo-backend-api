namespace UtosMoBackendAPI.Features.Users.DTO.Industries
{
    public class IndustryResponse
    {
        public Guid ID { get; set; }

        public required string Industry { get; set; }

        public bool IsActive { get; set; }
    }
}
