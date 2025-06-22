namespace UtosMoBackendAPI.Features.Bookings.Utilities
{
    public static class BookingResultMessage
    {
        public static string Added { get; } = "Booking has been added.";

        public static string Removed { get; } = "Booking has been removed.";

        public static string Updated { get; } = "Booking has been updated.";

        public static string Exists { get; } = "Booking already exists.";

        public static string NotFound { get; } = "Booking not found.";

        public static string NoChanges { get; set; } = "No changes has been made.";
    }
}
