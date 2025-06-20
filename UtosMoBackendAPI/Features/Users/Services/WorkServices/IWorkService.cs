using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Services.WorkServices
{
    public interface IWorkService
    {
        Task<Result<WorkModel>> AddWork(WorkModel work);
        Task<Result<string>> UpdateWork(WorkModel work);
        Task<Result<string>> DeleteWork(Guid workId);
        Task<Result<WorkModel>> GetWorkById(Guid workId);
    }
}
