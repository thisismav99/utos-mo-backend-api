﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using UtosMoBackendAPI.Features.Users.Commands.UserCommands;
using UtosMoBackendAPI.Features.Users.DTO.Users;
using UtosMoBackendAPI.Features.Users.Queries.UserQueries;
using UtosMoBackendAPI.Features.Users.Utilities;

namespace UtosMoBackendAPI.Features.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("User")]
    public class UserController : ControllerBase
    {
        #region Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var query = new GetUserByIdQuery(userId);

            var result = await _mediator.Send(query);

            if(result.IsFailure)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetUsersQuery();

            var result = await _mediator.Send(query);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]AddUserRequest addUserRequest)
        {
            var command = new AddUserCommand(addUserRequest);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { userId = result.Value.ID }, result.Value);
            }

            if(result.Error == UserResultMessage.Exists)
            {
                return Conflict();
            }

            return BadRequest(result.Error);
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var command = new DeleteUserCommand(userId);

            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody]UpdateUserRequest updateUserRequest)
        {
            var command = new UpdateUserCommand(userId, updateUserRequest);

            var result = await _mediator.Send(command);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
        #endregion
    }
}
