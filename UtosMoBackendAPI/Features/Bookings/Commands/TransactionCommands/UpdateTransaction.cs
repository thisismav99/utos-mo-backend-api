using CSharpFunctionalExtensions;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Transactions;
using UtosMoBackendAPI.Features.Bookings.Services.TransactionService;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Features.Bookings.Commands.TransactionCommands
{
    public record class UpdateTransactionCommand(
        Guid TransactionId, 
        string TransactionNo, 
        UpdateTransactionRequest UpdateTransactionRequest) : IRequest<Result<string>>;

    public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand, Result<string>>
    {
        #region Variable
        private readonly ITransactionService _transactionService;
        #endregion

        #region Constructor
        public UpdateTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        #endregion

        #region Method
        public async Task<Result<string>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new TransactionModel()
            {
                ID = request.TransactionId,
                TransactionNo = request.TransactionNo,
                IsCompleted = request.UpdateTransactionRequest.IsCompleted,
                CompletedDate = request.UpdateTransactionRequest.CompletedDate,
                IsActive = request.UpdateTransactionRequest.IsActive
            };

            var updateTransaction = await _transactionService.UpdateTransaction(transaction);

            return updateTransaction;
        }
        #endregion
    }
}
