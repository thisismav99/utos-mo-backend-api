using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UtosMoBackendAPI.Features.Bookings.Commands.TransactionCommands;
using UtosMoBackendAPI.Features.Bookings.DTO.Transactions;
using UtosMoBackendAPI.Features.Bookings.Queries.TransactionQueries;

namespace UtosMoBackendAPI.Features.Bookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Booking")]
    public class TransactionController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet("{transactionId:guid}")]
        public async Task<IActionResult> GetTransactionById(Guid transactionId)
        {
            var query = new GetTransactionByIdQuery(transactionId);

            var result = await _mediator.Send(query);

            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(AddTransactionRequest addTransactionRequest)
        {
            var command = new AddTransactionCommand(addTransactionRequest);

            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetTransactionById), new { transactionId = result.Value.ID }, result.Value);
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{transactionId:guid}")]
        public async Task<IActionResult> DeleteTransaction(Guid transactionId)
        {
            var command = new DeleteTransactionCommand(transactionId);

            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }

        [HttpPut("{transactionId:guid}/{transactionNo}")]
        public async Task<IActionResult> UpdateTransaction(
            Guid transactionId, 
            string transactionNo, 
            UpdateTransactionRequest updateTransactionRequest)
        {
            var command = new UpdateTransactionCommand(transactionId, transactionNo, updateTransactionRequest);

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
