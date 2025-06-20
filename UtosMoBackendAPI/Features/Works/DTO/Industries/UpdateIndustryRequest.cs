namespace UtosMoBackendAPI.Features.Works.DTO.Industries
{
    public class UpdateIndustryRequest
    {
        public required string Industry { get; set; }

        public bool IsActive { get; set; }
    }
}
