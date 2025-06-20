using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Works.DTO.Works;
using UtosMoBackendAPI.Features.Works.Services.WorkServices;

namespace UtosMoBackendAPI.Features.Works.Queries.WorkQueries
{
    public record class GetWorkByIdQuery(Guid id) : IRequest<Result<WorkResponse>>;

    public class GetWorkByIdHandler : IRequestHandler<GetWorkByIdQuery, Result<WorkResponse>>
    {
        #region Variable
        private readonly IWorkService _workService;
        #endregion

        #region Constructor
        public GetWorkByIdHandler(IWorkService workService)
        {
            _workService = workService;
        }
        #endregion

        #region Method
        public async Task<Result<WorkResponse>> Handle(GetWorkByIdQuery request, CancellationToken cancellationToken)
        {
            var work = await _workService.GetWorkById(request.id);

            if (work.IsSuccess)
            {
                WorkResponse workDTO = work.Value.Adapt<WorkResponse>();

                return Result.Success(workDTO);
            }

            return Result.Failure<WorkResponse>(work.Error);
        }
        #endregion
    }
}
