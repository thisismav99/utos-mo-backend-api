using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Reviews.DTO.Reviews;
using UtosMoBackendAPI.Features.Reviews.Services.ReviewServices;

namespace UtosMoBackendAPI.Features.Reviews.Queries.ReviewQueries
{
    public record class GetReviewByIdQuery(Guid id) : IRequest<Result<ReviewResponse>>;

    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Result<ReviewResponse>>
    {
        #region Variable
        private readonly IReviewService _reviewService;
        #endregion

        #region Constructor
        public GetReviewByIdHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        #endregion

        #region Method
        public async Task<Result<ReviewResponse>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewService.GetReviewById(request.id);

            if (review.IsSuccess)
            {
                ReviewResponse reviewDTO = review.Value.Adapt<ReviewResponse>();

                return Result.Success(reviewDTO);
            }

            return Result.Failure<ReviewResponse>(review.Error);
        }
        #endregion
    }
}
