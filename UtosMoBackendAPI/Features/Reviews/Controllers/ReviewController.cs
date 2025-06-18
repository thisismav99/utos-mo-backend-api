using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UtosMoBackendAPI.Features.Reviews.Commands.ReviewCommands;
using UtosMoBackendAPI.Features.Reviews.DTO.Reviews;
using UtosMoBackendAPI.Features.Reviews.Queries.ReviewQueries;
using UtosMoBackendAPI.Features.Reviews.Utilities;

namespace UtosMoBackendAPI.Features.Reviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet("{reviewId:guid}")]
        public async Task<IActionResult> GetById(Guid reviewId)
        {
            var command = new GetReviewByIdQuery(reviewId);

            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpGet("~/api/Reviews/{userId:guid}")]
        public async Task<IActionResult> GetAllBy(Guid userId)
        {
            var command = new GetReviewsByUserIdQuery(userId);

            var result = await _mediator.Send(command);

            if(result.IsSuccess && !result.Value.IsNullOrEmpty())
            {
                return Ok(result.Value);
            }
            else if(result.IsSuccess && result.Value.IsNullOrEmpty())
            {
                return NotFound();
            }

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddReviewRequest addReviewRequest)
        {
            var command = new AddReviewCommand(addReviewRequest);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { reviewId = result.Value.ID }, result.Value);
            }

            if (result.Error == ReviewResultMessage.Exists)
            {
                return Conflict();
            }
            
            return BadRequest(result.Error);
        }

        [HttpPut("{reviewId:guid}")]
        public async Task<IActionResult> Update(Guid reviewId, UpdateReviewRequest updateReviewRequest)
        {
            var command = new UpdateReviewCommand(reviewId, updateReviewRequest);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }
        #endregion
    }
}
