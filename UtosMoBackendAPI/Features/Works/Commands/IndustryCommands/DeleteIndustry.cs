using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Works.Services.IndustryServices;

namespace UtosMoBackendAPI.Features.Works.Commands.IndustryCommands
{
    public record class DeleteIndustryCommand(Guid id) : IRequest<Result<string>>;

    public class DeleteIndustryHandler : IRequestHandler<DeleteIndustryCommand, Result<string>>
    {
        #region Variable
        private readonly IIndustryService _industryService;
        #endregion

        #region Constructor
        public DeleteIndustryHandler(IIndustryService industryService)
        {
            _industryService = industryService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(DeleteIndustryCommand request, CancellationToken cancellationToken)
        {
            var deleteIndustry = await _industryService.DeleteIndustry(request.id);

            return deleteIndustry;
        }
        #endregion
    }
}
