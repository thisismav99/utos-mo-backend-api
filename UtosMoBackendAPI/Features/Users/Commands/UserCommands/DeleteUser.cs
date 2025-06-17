using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Users.Services.UserServices;

namespace UtosMoBackendAPI.Features.Users.Commands.UserCommands
{
    public record class DeleteUserCommand(Guid id) : IRequest<Result<string>>;

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        #region Variable
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public DeleteUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deleteUser = await _userService.DeleteUser(request.id);

            return deleteUser;
        }
        #endregion
    }
}
