namespace UtosMoBackendAPI.Features.Users.DTO.Industries
{
    public class UpdateIndustryRequest
    {
        public required string Industry { get; set; }

        public bool IsActive { get; set; }
    }
}
