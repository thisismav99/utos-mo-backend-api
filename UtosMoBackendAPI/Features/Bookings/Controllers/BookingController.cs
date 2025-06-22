using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using UtosMoBackendAPI.Features.Bookings.Commands.BookingCommands;
using UtosMoBackendAPI.Features.Bookings.DTO.Bookings;
using UtosMoBackendAPI.Features.Bookings.Queries.BookingQueries;

namespace UtosMoBackendAPI.Features.Bookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Booking")]
    public class BookingController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet("{bookingId:guid}")]
        public async Task<IActionResult> GetBookingById(Guid bookingId) 
        { 
            var query = new GetBookingByIdQuery(bookingId);

            var result = await _mediator.Send(query);

            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return NotFound();
        }

        [HttpGet("~/api/BookBy/{bookBy:guid}")]
        public async Task<IActionResult> GetBookingByBookBy(Guid bookBy)
        {
            var query = new GetBookingByBookByQuery(bookBy);

            var result = await _mediator.Send(query);

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

        [HttpGet("~/api/BookTo/{bookTo:guid}")]
        public async Task<IActionResult> GetBookingByBookTo(Guid bookTo)
        {
            var query = new GetBookingByBookToQuery(bookTo);

            var result = await _mediator.Send(query);

            if (result.IsSuccess && !result.Value.IsNullOrEmpty())
            {
                return Ok(result.Value);
            }
            else if (result.IsSuccess && result.Value.IsNullOrEmpty())
            {
                return NotFound();
            }

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingRequest addBookingRequest)
        {
            var command = new AddBookingCommand(addBookingRequest);

            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetBookingById), new { bookingId = result.Value.ID }, result.Value);
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{bookingId:guid}")]
        public async Task<IActionResult> DeleteBooking(Guid bookingId)
        {
            var command = new DeleteBookingCommand(bookingId);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest(result.Error);
        }

        [HttpPut("{bookingId:guid}")]
        public async Task<IActionResult> UpdateBooking(Guid bookingId, UpdateBookingRequest updateBookingRequest)
        {
            var command = new UpdateBookingCommand(bookingId, updateBookingRequest);

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
