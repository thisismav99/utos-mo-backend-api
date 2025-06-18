using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Models.ReviewModels;

namespace UtosMoBackendAPI.Features.Reviews.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<Result<ReviewModel?>> GetReviewById(Guid reviewId);
        Task<Result<List<ReviewModel>?>> GetAllReviewsByUserId(Guid userId);
        Task<Result<ReviewModel>> AddReview(ReviewModel review);
        Task<Result<string>> UpdateReview(ReviewModel review);
    }
}
