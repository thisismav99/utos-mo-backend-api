using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Contexts;
using UtosMoBackendAPI.Features.Reviews.Utilities;
using UtosMoBackendAPI.Models.ReviewModels;
using UtosMoBackendAPI.RepositoryManager;

namespace UtosMoBackendAPI.Features.Reviews.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        #region Variables
        private readonly IRepository<ReviewModel, ReviewDbContext> _repository;
        #endregion

        #region Constructor
        public ReviewService(IRepository<ReviewModel, ReviewDbContext> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<Result<ReviewModel>> AddReview(ReviewModel review)
        {
            var reviewExists = await _repository.HasMatch(x => x.Title == review.Title &&
                                                               x.Description == review.Description &&
                                                               x.Rating == review.Rating &&
                                                               x.UserID == review.UserID);

            if(reviewExists)
            {
                return Result.Failure<ReviewModel>(ReviewResultMessage.Exists);
            }

            var validateRating = ReviewValidationHelper<ReviewModel>.ValidateRating(review.Rating);

            if (validateRating.IsFailure)
            {
                return validateRating;
            }

            await _repository.Add(review);

            return Result.Success(review);
        }

        public async Task<Result<List<ReviewModel>?>> GetAllReviewsByUserId(Guid userId)
        {
            var reviewsByUserId = await _repository.GetAllBy(x => x.UserID == userId);

            if(reviewsByUserId is null)
            {
                return Result.Failure<List<ReviewModel>?>(ReviewResultMessage.NotFound);
            }

            return Result.Success<List<ReviewModel>?>(reviewsByUserId);
        }

        public async Task<Result<ReviewModel?>> GetReviewById(Guid reviewId)
        {
            var review = await _repository.GetById(reviewId);

            if(review is null)
            {
                return Result.Failure<ReviewModel?>(ReviewResultMessage.NotFound);
            }

            return Result.Success<ReviewModel?>(review);
        }

        public async Task<Result<string>> UpdateReview(ReviewModel review)
        {
            var isExactReview = await _repository.HasMatch(x => x.ID ==  review.ID &&
                                                                x.Title == review.Title &&
                                                                x.Description == review.Description &&
                                                                x.Rating == review.Rating &&
                                                                x.UserID == review.UserID);

            if (isExactReview)
            {
                return Result.Failure<string>(ReviewResultMessage.NoChanges);
            }

            var validateRating = ReviewValidationHelper<string>.ValidateRating(review.Rating);

            if (validateRating.IsFailure)
            {
                return validateRating;
            }

            await _repository.Update(review);

            return Result.Success(ReviewResultMessage.Updated);
        }
        #endregion
    }
}
