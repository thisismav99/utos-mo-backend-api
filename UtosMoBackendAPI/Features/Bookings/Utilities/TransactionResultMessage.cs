namespace UtosMoBackendAPI.Features.Bookings.Utilities
{
    public static class TransactionResultMessage
    {
        public static string Added { get; } = "Transaction has been added.";

        public static string Removed { get; } = "Transaction has been removed.";

        public static string Updated { get; } = "Transaction has been updated.";

        public static string Exists { get; } = "Transaction already exists.";

        public static string NotFound { get; } = "Transaction not found.";

        public static string LatestNotFound { get; } = "Latest transaction not found.";

        public static string UnableToGenerate { get; } = "Unable to generate Transaction Number.";

        public static string NoChanges { get; set; } = "No changes has been made.";
    }
}
