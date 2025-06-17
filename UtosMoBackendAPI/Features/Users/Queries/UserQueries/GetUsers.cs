using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Users;
using UtosMoBackendAPI.Features.Users.Services.UserServices;

namespace UtosMoBackendAPI.Features.Users.Queries.UserQueries
{
    public record class GetUsersQuery : IRequest<List<UserResponse>>;

    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        #region Variable
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public GetUsersHandler(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Method
        public async Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsers();
            List<UserResponse> usersDTO = users.Adapt<List<UserResponse>>();

            return usersDTO;
        }
        #endregion
    }
}
