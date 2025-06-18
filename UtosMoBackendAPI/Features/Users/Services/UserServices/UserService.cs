using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Contexts;
using UtosMoBackendAPI.Features.Users.Utilities;
using UtosMoBackendAPI.Models.UserModels;
using UtosMoBackendAPI.RepositoryManager;

namespace UtosMoBackendAPI.Features.Users.Services.UserServices
{
    public class UserService : IUserService
    {
        #region Variables
        private readonly IRepository<UserModel, UserDbContext> _repository;
        #endregion

        #region Constructor
        public UserService(IRepository<UserModel, UserDbContext> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<Result<UserModel>> AddUser(UserModel user)
        {
            var userExists = await _repository.HasMatch(x => x!.FirstName == user.FirstName &&
                                                             x.MiddleName == user.MiddleName &&
                                                             x.LastName == user.LastName);

            if (userExists)
            {
                return Result.Failure<UserModel>(UserResultMessage.Exists);
            }

            await _repository.Add(user);

            return Result.Success(user);
        }

        public async Task<Result<string>> DeleteUser(Guid userId)
        {
            var userExists = await _repository.GetById(userId);

            if (userExists is not null)
            {
                await _repository.Delete(userExists);

                return Result.Success(UserResultMessage.Removed);
            }

            return Result.Failure<string>(UserResultMessage.NotFound);
        }

        public async Task<List<UserModel>?> GetAllUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<Result<UserModel?>> GetUserById(Guid userId)
        {
            var userExists = await _repository.GetById(userId);

            if (userExists is not null)
            {
                return Result.Success<UserModel?>(userExists);
            }
            else
            {
                return Result.Failure<UserModel?>(UserResultMessage.NotFound);
            }
        }

        public async Task<Result<string>> UpdateUser(UserModel user)
        {
            var isExactUser = await _repository.HasMatch(x => x.ID == user.ID &&
                                                              x.FirstName == user.FirstName &&
                                                              x.MiddleName == user.MiddleName &&
                                                              x.LastName == user.LastName &&
                                                              x.ContactNumber == user.ContactNumber &&
                                                              x.SocialMediaLink == user.SocialMediaLink &&
                                                              x.IsVerified == user.IsVerified &&
                                                              x.IsActive == user.IsActive);

            if (isExactUser)
            {
                return Result.Failure<string>(UserResultMessage.NoChanges);
            }

            await _repository.Update(user);

            return Result.Success(UserResultMessage.Updated);
        }
        #endregion
    }
}
