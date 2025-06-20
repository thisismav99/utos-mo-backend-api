using MediatR;
using Microsoft.AspNetCore.Mvc;
using UtosMoBackendAPI.Features.Works.Commands.IndustryCommands;
using UtosMoBackendAPI.Features.Works.DTO.Industries;
using UtosMoBackendAPI.Features.Works.Queries.IndustryQueries;

namespace UtosMoBackendAPI.Features.Works.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public IndustryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet("{industryId:guid}")]
        public async Task<IActionResult> GetById(Guid industryId)
        {
            var query = new GetIndustryByIdQuery(industryId);

            var result = await _mediator.Send(query);

            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddIndustry(AddIndustryRequest addIndustryRequest)
        {
            var command = new AddIndustryCommand(addIndustryRequest);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { industryId = result.Value.ID}, result.Value);
            }

            return BadRequest(result.Error);
        }

        [HttpPut("{industryId:guid}")]
        public async Task<IActionResult> UpdateIndustry(Guid industryId, UpdateIndustryRequest updateIndustryRequest)
        {
            var command = new UpdateIndustryCommand(industryId, updateIndustryRequest);

            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{industryId:guid}")]
        public async Task<IActionResult> DeleteIndustry(Guid industryId)
        {
            var command = new DeleteIndustryCommand(industryId);

            var result = await _mediator.Send(command);

            if(result.IsSuccess) 
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }
        #endregion
    }
}
