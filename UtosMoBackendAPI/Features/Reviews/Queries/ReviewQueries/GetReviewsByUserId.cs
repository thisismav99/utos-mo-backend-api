using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Reviews.DTO.Reviews;
using UtosMoBackendAPI.Features.Reviews.Services.ReviewServices;

namespace UtosMoBackendAPI.Features.Reviews.Queries.ReviewQueries
{
    public record class GetReviewsByUserIdQuery(Guid id) : IRequest<Result<List<ReviewResponse>>>;

    public class GetReviewsByIdHandler : IRequestHandler<GetReviewsByUserIdQuery, Result<List<ReviewResponse>>>
    {
        #region Variable
        private readonly IReviewService _reviewService;
        #endregion

        #region Constructor
        public GetReviewsByIdHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        #endregion

        #region Methods
        public async Task<Result<List<ReviewResponse>>> Handle(GetReviewsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewService.GetAllReviewsByUserId(request.id);

            if(reviews.IsSuccess)
            {
                List<ReviewResponse> reviewsDTO = reviews.Value.Adapt<List<ReviewResponse>>();

                return Result.Success(reviewsDTO);
            }

            return Result.Failure<List<ReviewResponse>>(reviews.Error);
        }
        #endregion
    }
}
