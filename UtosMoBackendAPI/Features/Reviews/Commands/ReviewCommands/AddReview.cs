using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Reviews.DTO.Reviews;
using UtosMoBackendAPI.Features.Reviews.Services.ReviewServices;
using UtosMoBackendAPI.Models.ReviewModels;

namespace UtosMoBackendAPI.Features.Reviews.Commands.ReviewCommands
{
    public record class AddReviewCommand(AddReviewRequest addReviewRequest) : IRequest<Result<ReviewResponse>>;

    public class AddReviewHandler : IRequestHandler<AddReviewCommand, Result<ReviewResponse>>
    {
        #region Variable
        private readonly IReviewService _reviewService;
        #endregion

        #region Constructor
        public AddReviewHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        #endregion

        #region Method
        public async Task<Result<ReviewResponse>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new ReviewModel()
            {
                Title = request.addReviewRequest.Title,
                Description = request.addReviewRequest.Description,
                Rating = request.addReviewRequest.Rating,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsActive = true,
                UserID = request.addReviewRequest.UserID
            };

            var addReview = await _reviewService.AddReview(review);

            if(addReview.IsSuccess)
            {
                ReviewResponse reviewDTO = addReview.Value.Adapt<ReviewResponse>();

                return Result.Success(reviewDTO);
            }

            return Result.Failure<ReviewResponse>(addReview.Error);
        }
        #endregion
    }
}
