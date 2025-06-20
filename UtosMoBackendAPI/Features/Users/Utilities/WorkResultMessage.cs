namespace UtosMoBackendAPI.Features.Users.Utilities
{
    public static class WorkResultMessage
    {
        public static string Exists { get; } = "Work already exists.";

        public static string Deleted { get; } = "Work has been deleted.";

        public static string NotFound { get; } = "Work not found.";

        public static string NoChanges { get; } = "No changes has been made.";

        public static string Updated { get; } = "Work has been updated.";
    }
}
