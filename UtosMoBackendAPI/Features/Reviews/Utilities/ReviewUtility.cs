using CSharpFunctionalExtensions;

namespace UtosMoBackendAPI.Features.Reviews.Utilities
{
    public static class ReviewUtility<T> where T : class
    {
        public static Result<T> ValidateRating(int rating)
        {
            string message = string.Empty;

            if (rating > 5)
            {
                message = ReviewResultMessage.RatingExceed;
            }
            else if (rating < 0)
            {
                message = ReviewResultMessage.RatingInvalid;
            }

            return Result.Failure<T>(message);
        }
    }
}
