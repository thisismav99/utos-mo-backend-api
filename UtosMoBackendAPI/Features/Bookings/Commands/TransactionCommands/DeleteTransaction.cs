using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.Services.TransactionService;

namespace UtosMoBackendAPI.Features.Bookings.Commands.TransactionCommands
{
    public record class DeleteTransactionCommand(Guid TransactionId) : IRequest<Result<string>>;

    public class DeleteTransactionHandler : IRequestHandler<DeleteTransactionCommand, Result<string>>
    {
        #region Variable
        private readonly ITransactionService _transactionService;
        #endregion

        #region Constructor
        public DeleteTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var deleteTransaction = await _transactionService.DeleteTransaction(request.TransactionId);

            return deleteTransaction;
        }
        #endregion
    }
}
