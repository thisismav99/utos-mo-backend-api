namespace UtosMoBackendAPI.Features.Users.DTO.Works
{
    public class UpdateWorkRequest
    {
        public required string Title { get; set; }

        public int YearsExperience { get; set; }

        public bool IsCredited { get; set; }

        public bool IsActive { get; set; }
    }
}
