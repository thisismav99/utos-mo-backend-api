using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Works;
using UtosMoBackendAPI.Features.Users.Services.WorkServices;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Commands.WorkCommands
{
    public record class UpdateWorkCommand(Guid id, UpdateWorkRequest updateWorkRequest) : IRequest<Result<string>>;

    public class UpdateWorkHandler : IRequestHandler<UpdateWorkCommand, Result<string>>
    {
        #region Variable
        private readonly IWorkService _workService;
        #endregion

        #region Constructor
        public UpdateWorkHandler(IWorkService workService)
        {
            _workService = workService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
        {
            var work = new WorkModel()
            {
                ID = request.id,
                Title = request.updateWorkRequest.Title,
                YearsExperience = request.updateWorkRequest.YearsExperience,
                IsCredited = request.updateWorkRequest.IsCredited,
                IsActive = request.updateWorkRequest.IsActive,
            };

            var updateWork = await _workService.UpdateWork(work);

            return updateWork;
        }
        #endregion
    }
}
