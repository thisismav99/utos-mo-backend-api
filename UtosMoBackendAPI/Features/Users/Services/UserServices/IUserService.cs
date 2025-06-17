using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Services.UserServices
{
    public interface IUserService
    {
        Task<Result<UserModel>> AddUser(UserModel user);
        Task<Result<string>> UpdateUser(UserModel user);
        Task<Result<string>> DeleteUser(Guid userId);
        Task<Result<UserModel?>> GetUserById(Guid userId);
        Task<List<UserModel>?> GetAllUsers();

    }
}
