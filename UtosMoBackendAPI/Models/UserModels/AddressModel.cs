namespace UtosMoBackendAPI.Models.UserModels
{
    public class AddressModel : BaseModel
    {
        public string? LotNo { get; set; }

        public string? Street { get; set; }

        public required string Barangay { get; set; }

        public required string City { get; set; }

        public required string Region { get; set; }

        public required string Country { get; set; }
    }
}
