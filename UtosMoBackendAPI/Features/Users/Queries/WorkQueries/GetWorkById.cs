using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Works;
using UtosMoBackendAPI.Features.Users.Services.WorkServices;

namespace UtosMoBackendAPI.Features.Users.Queries.WorkQueries
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
