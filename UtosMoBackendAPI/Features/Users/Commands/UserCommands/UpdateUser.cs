using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Users;
using UtosMoBackendAPI.Features.Users.Services.UserServices;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Commands.UserCommands
{
    public record class UpdateUserCommand(Guid id, UpdateUserRequest updateUserRequest) : IRequest<Result<string>>;

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<string>>
    {
        #region Variable
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel
            {
                ID = request.id,
                FirstName = request.updateUserRequest.FirstName,
                MiddleName = request.updateUserRequest.MiddleName,
                LastName = request.updateUserRequest.LastName,
                ContactNumber = request.updateUserRequest.ContactNumber,
                SocialMediaLink = request.updateUserRequest?.SocialMediaLink,
                IsVerified = request.updateUserRequest!.IsVerified,
                IsActive = request.updateUserRequest.IsActive
            };

            var updateUser = await _userService.UpdateUser(user);

            return updateUser;
        }
        #endregion
    }
}
