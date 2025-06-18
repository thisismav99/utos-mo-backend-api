namespace UtosMoBackendAPI.Features.Reviews.Utilities
{
    public static class ReviewResultMessage
    {
        public static string Exists { get; } = "Review already exists.";

        public static string NoChanges { get; } = "No changes has been made.";

        public static string Updated { get; } = "Review has been updated.";

        public static string NotFound { get; } = "Review not found.";

        public static string RatingExceed { get; } = "Review rating exceeded.";

        public static string RatingInvalid { get; } = "Review rating is invalid.";
    }
}
