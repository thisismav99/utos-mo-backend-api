using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Contexts;
using UtosMoBackendAPI.Features.Users.Utilities;
using UtosMoBackendAPI.Models.UserModels;
using UtosMoBackendAPI.RepositoryManager;

namespace UtosMoBackendAPI.Features.Users.Services.WorkServices
{
    public class WorkService : IWorkService
    {
        #region Variables
        private readonly IRepository<WorkModel, UserDbContext> _repository;
        #endregion

        #region Constructor
        public WorkService(IRepository<WorkModel, UserDbContext> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<Result<WorkModel>> AddWork(WorkModel work)
        {
            var isWorkExists = await _repository.HasMatch(x => x.Title == work.Title &&
                                                               x.YearsExperience == work.YearsExperience &&
                                                               x.UserID == work.UserID);

            if (isWorkExists)
            {
                return Result.Failure<WorkModel>(WorkResultMessage.Exists);
            }

            await _repository.Add(work);

            return Result.Success(work);
        }

        public async Task<Result<string>> DeleteWork(Guid workId)
        {
            var work = await _repository.GetById(workId);

            if (work is not null)
            {
                await _repository.Delete(work);

                return Result.Success(WorkResultMessage.Deleted);
            }

            return Result.Failure<string>(WorkResultMessage.NotFound);
        }

        public async Task<Result<WorkModel>> GetWorkById(Guid workId)
        {
            var work = await _repository.GetById(workId);

            if (work is not null)
            {
                return Result.Success(work);
            }

            return Result.Failure<WorkModel>(WorkResultMessage.NotFound);
        }

        public async Task<Result<string>> UpdateWork(WorkModel work)
        {
            var isExactWork = await _repository.HasMatch(x => x.ID == work.ID &&
                                                              x.Title == work.Title &&
                                                              x.YearsExperience == work.YearsExperience &&
                                                              x.IsCredited == work.IsCredited &&
                                                              x.IsActive == work.IsActive &&
                                                              x.UserID == work.UserID);

            if (isExactWork)
            {
                return Result.Failure<string>(WorkResultMessage.NoChanges);
            }

            await _repository.Update(work);

            return Result.Success(WorkResultMessage.Updated);
        }
        #endregion
    }
}
