using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Users;
using UtosMoBackendAPI.Features.Users.Services.UserServices;

namespace UtosMoBackendAPI.Features.Users.Queries.UserQueries
{
    public record class GetUserByIdQuery(Guid id) : IRequest<Result<UserResponse>>;

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        #region Variable
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(request.id);

            if(user.IsSuccess)
            {
                UserResponse userDTO = user.Value.Adapt<UserResponse>();

                return Result.Success(userDTO);
            }

            return Result.Failure<UserResponse>(user.Error);
        }
        #endregion
    }
}
