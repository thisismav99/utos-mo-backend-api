using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Contexts;
using UtosMoBackendAPI.Features.Works.Utilities;
using UtosMoBackendAPI.Models.WorkModels;
using UtosMoBackendAPI.RepositoryManager;

namespace UtosMoBackendAPI.Features.Works.Services.IndustryServices
{
    public class IndustryService : IIndustryService
    {
        #region Variables
        private readonly IRepository<IndustryModel, WorkDbContext> _repository;
        #endregion

        #region Constructor
        public IndustryService(IRepository<IndustryModel, WorkDbContext> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<Result<IndustryModel>> AddIndustry(IndustryModel industry)
        {
            var isIndustryExists = await _repository.HasMatch(x => x.Industry == industry.Industry);
            
            if(isIndustryExists)
            {
                return Result.Failure<IndustryModel>(IndustryResultMessage.Exists);
            }

            await _repository.Add(industry);

            return Result.Success(industry);
        }

        public async Task<Result<string>> DeleteIndustry(Guid industryId)
        {
            var industry = await _repository.GetById(industryId);

            if(industry is not null)
            {
                await _repository.Delete(industry);

                return Result.Success(IndustryResultMessage.Deleted);
            }

            return Result.Failure<string>(IndustryResultMessage.NotFound);
        }

        public async Task<Result<IndustryModel>> GetIndustryById(Guid industryId)
        {
            var industry = await _repository.GetById(industryId);

            if(industry is not null)
            {
                return Result.Success(industry);
            }

            return Result.Failure<IndustryModel>(IndustryResultMessage.NotFound);
        }

        public async Task<Result<string>> UpdateIndustry(IndustryModel industry)
        {
            var isExactIndustry = await _repository.HasMatch(x => x.ID == industry.ID &&
                                                                  x.Industry == industry.Industry &&
                                                                  x.IsActive == industry.IsActive);

            if(isExactIndustry)
            {
                return Result.Failure<string>(IndustryResultMessage.NoChanges);
            }

            await _repository.Update(industry);

            return Result.Success(IndustryResultMessage.Updated);
        }
        #endregion
    }
}
