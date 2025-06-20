using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Works.DTO.Industries;
using UtosMoBackendAPI.Features.Works.Services.IndustryServices;
using UtosMoBackendAPI.Models.WorkModels;

namespace UtosMoBackendAPI.Features.Works.Commands.IndustryCommands
{
    public record class AddIndustryCommand(AddIndustryRequest addIndustryRequest) : IRequest<Result<IndustryResponse>>;

    public class AddIndustryHandler : IRequestHandler<AddIndustryCommand, Result<IndustryResponse>>
    {
        #region Variable
        private readonly IIndustryService _industryService;
        #endregion

        #region Constructor
        public AddIndustryHandler(IIndustryService industryService)
        {
            _industryService = industryService;
        }
        #endregion

        #region Method
        public async Task<Result<IndustryResponse>> Handle(AddIndustryCommand request, CancellationToken cancellationToken)
        {
            var industry = new IndustryModel()
            {
                Industry = request.addIndustryRequest.Industry,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            var addIndustry = await _industryService.AddIndustry(industry);

            if (addIndustry.IsSuccess)
            {
                IndustryResponse industryDTO = addIndustry.Value.Adapt<IndustryResponse>();

                return Result.Success(industryDTO);
            }

            return Result.Failure<IndustryResponse>(addIndustry.Error);
        }
        #endregion
    }
}
