using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Users;
using UtosMoBackendAPI.Features.Users.Services.UserServices;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Commands.UserCommands
{
    public record class AddUserCommand(AddUserRequest addUserRequest) : IRequest<Result<UserResponse>>;

    public class AddUserHandler : IRequestHandler<AddUserCommand, Result<UserResponse>>
    {
        #region Variable
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public AddUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<Result<UserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel()
            {
                FirstName = request.addUserRequest.FirstName,
                MiddleName = request.addUserRequest.MiddleName,
                LastName = request.addUserRequest.LastName,
                ContactNumber = request.addUserRequest.ContactNumber,
                SocialMediaLink = request.addUserRequest?.SocialMediaLink,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            var addUser = await _userService.AddUser(user);

            if(addUser.IsSuccess)
            {
                UserResponse userDTO = addUser.Value.Adapt<UserResponse>();

                return Result.Success(userDTO);
            }

            return Result.Failure<UserResponse>(addUser.Error);
        }
        #endregion
    }
}
