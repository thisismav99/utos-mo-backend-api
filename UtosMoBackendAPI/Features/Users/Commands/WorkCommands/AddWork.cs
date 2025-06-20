using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Users.DTO.Works;
using UtosMoBackendAPI.Features.Users.Services.WorkServices;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Features.Users.Commands.WorkCommands
{
    public record class AddWorkCommand(AddWorkRequest addWorkRequest) : IRequest<Result<WorkResponse>>;

    public class AddWorkHandler : IRequestHandler<AddWorkCommand, Result<WorkResponse>>
    {
        #region Variable
        private readonly IWorkService _workService;
        #endregion

        #region Constructor
        public AddWorkHandler(IWorkService workService)
        {
            _workService = workService;
        }
        #endregion

        #region Method
        public async Task<Result<WorkResponse>> Handle(AddWorkCommand request, CancellationToken cancellationToken)
        {
            var work = new WorkModel()
            {
                Title = request.addWorkRequest.Title,
                YearsExperience = request.addWorkRequest.YearsExperience,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            var addWork = await _workService.AddWork(work);

            if (addWork.IsSuccess)
            {
                WorkResponse workDTO = addWork.Value.Adapt<WorkResponse>();

                return Result.Success(workDTO);
            }

            return Result.Failure<WorkResponse>(addWork.Error);
        }
        #endregion
    }
}
