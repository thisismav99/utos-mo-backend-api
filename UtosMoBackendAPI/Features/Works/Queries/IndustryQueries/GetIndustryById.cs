using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Works.DTO.Industries;
using UtosMoBackendAPI.Features.Works.Services.IndustryServices;

namespace UtosMoBackendAPI.Features.Works.Queries.IndustryQueries
{
    public record class GetIndustryByIdQuery(Guid id) : IRequest<Result<IndustryResponse>>;

    public class GetIndustryHandler : IRequestHandler<GetIndustryByIdQuery, Result<IndustryResponse>>
    {
        #region Variable
        private readonly IIndustryService _industryService;
        #endregion

        #region Constructor
        public GetIndustryHandler(IIndustryService industryService)
        {
            _industryService = industryService;
        }
        #endregion

        #region Method
        public async Task<Result<IndustryResponse>> Handle(GetIndustryByIdQuery request, CancellationToken cancellationToken)
        {
            var industry = await _industryService.GetIndustryById(request.id);

            if (industry.IsSuccess)
            {
                IndustryResponse industryDTO = industry.Value.Adapt<IndustryResponse>();

                return Result.Success(industryDTO);
            }

            return Result.Failure<IndustryResponse>(industry.Error);
        }
        #endregion
    }
}
