namespace UtosMoBackendAPI.Features.Works.Utilities
{
    public static class IndustryResultMessage
    {
        public static string Exists { get; } = "Industry already exists.";

        public static string Deleted { get; } = "Industry has been deleted.";

        public static string NotFound { get; } = "Industry not found.";

        public static string NoChanges { get; } = "No changes has been made.";

        public static string Updated { get; } = "Industry has been updated.";
    }
}
