namespace UtosMoBackendAPI.Features.Users.Utilities
{
    public static class UserResultMessage
    {
        public static string Added { get; } = "User has been added.";

        public static string Removed { get; } = "User has been removed.";

        public static string Updated { get; } = "User has been updated.";

        public static string Exists { get; } = "User already exists.";

        public static string NotFound { get; } = "User not found.";

        public static string NoChanges { get; set; } = "No changes has been made.";
    }
}
