using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UtosMoBackendAPI.Features.Users.Commands.WorkCommands;
using UtosMoBackendAPI.Features.Users.DTO.Works;
using UtosMoBackendAPI.Features.Users.Queries.WorkQueries;

namespace UtosMoBackendAPI.Features.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("User")]
    public class WorkController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public WorkController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet("{workId:guid}")]
        public async Task<IActionResult> GetById(Guid workId)
        {
            var query = new GetWorkByIdQuery(workId);

            var result = await _mediator.Send(query);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddWork(AddWorkRequest addWorkRequest)
        {
            var command = new AddWorkCommand(addWorkRequest);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { workId = result.Value.ID }, result.Value);
            }

            return BadRequest(result.Error);
        }

        [HttpPut("{workId:guid}")]
        public async Task<IActionResult> UpdateWork(Guid workId, UpdateWorkRequest updateWorkRequest)
        {
            var command = new UpdateWorkCommand(workId, updateWorkRequest);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{workId:guid}")]
        public async Task<IActionResult> DeleteWork(Guid workId)
        {
            var command = new DeleteWorkCommand(workId);

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
