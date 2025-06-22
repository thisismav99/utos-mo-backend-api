using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Services.IndustryServices
{
    public interface IIndustryService
    {
        Task<Result<IndustryModel>> AddIndustry(IndustryModel industry);
        Task<Result<string>> UpdateIndustry(IndustryModel industry);
        Task<Result<string>> DeleteIndustry(Guid industryId);
        Task<Result<IndustryModel?>> GetIndustryById(Guid industryId);
    }
}
