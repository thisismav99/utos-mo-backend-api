using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Industries;
using UtosMoBackendAPI.Features.Users.Services.IndustryServices;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Commands.IndustryCommands
{
    public record class UpdateIndustryCommand(Guid id, UpdateIndustryRequest updateIndustryRequest) : IRequest<Result<string>>;

    public class UpdateIndustryHandler : IRequestHandler<UpdateIndustryCommand, Result<string>>
    {
        #region Variable
        private readonly IIndustryService _industryService;
        #endregion

        #region Constructor
        public UpdateIndustryHandler(IIndustryService industryService)
        {
            _industryService = industryService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(UpdateIndustryCommand request, CancellationToken cancellationToken)
        {
            var industry = new IndustryModel()
            {
                ID = request.id,
                Industry = request.updateIndustryRequest.Industry,
                IsActive = request.updateIndustryRequest.IsActive
            };

            var updateIndustry = await _industryService.UpdateIndustry(industry);

            return updateIndustry;
        }
        #endregion
    }
}
