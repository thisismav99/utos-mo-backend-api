using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Reviews.DTO.Reviews;
using UtosMoBackendAPI.Features.Reviews.Services.ReviewServices;
using UtosMoBackendAPI.Models.ReviewModels;

namespace UtosMoBackendAPI.Features.Reviews.Commands.ReviewCommands
{
    public record class UpdateReviewCommand(Guid id, UpdateReviewRequest updateReviewRequest) : IRequest<Result<string>>;

    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Result<string>>
    {
        #region Variable
        private readonly IReviewService _reviewService;
        #endregion

        #region Constructor
        public UpdateReviewHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new ReviewModel()
            {
                ID = request.id,
                Title = request.updateReviewRequest.Title,
                Description = request.updateReviewRequest.Description,
                Rating = request.updateReviewRequest.Rating,
                IsActive = request.updateReviewRequest.IsActive,
                UserID = request.updateReviewRequest.UserID
            };

            var updateReview = await _reviewService.UpdateReview(review);

            return updateReview;
        }
        #endregion
    }
}
