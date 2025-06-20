using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Works.Services.WorkServices;

namespace UtosMoBackendAPI.Features.Works.Commands.WorkCommands
{
    public record class DeleteWorkCommand(Guid id) : IRequest<Result<string>>;

    public class DeleteWorkHandler : IRequestHandler<DeleteWorkCommand, Result<string>>
    {
        #region Variable
        private readonly IWorkService _workService;
        #endregion

        #region Constructor
        public DeleteWorkHandler(IWorkService workService)
        {
            _workService = workService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(DeleteWorkCommand request, CancellationToken cancellationToken)
        {
            var deleteWork = await _workService.DeleteWork(request.id);

            return deleteWork;
        }
        #endregion
    }
}
