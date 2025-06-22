using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Transactions;
using UtosMoBackendAPI.Features.Bookings.Services.TransactionService;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Features.Bookings.Commands.TransactionCommands
{
    public record class AddTransactionCommand(AddTransactionRequest AddTransactionRequest) : IRequest<Result<TransactionResponse>>;

    public class AddTransactionHandler : IRequestHandler<AddTransactionCommand, Result<TransactionResponse>>
    {
        #region Variable
        private readonly ITransactionService _transactionService;
        #endregion

        #region Constructor
        public AddTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        #endregion

        #region Method
        public async Task<Result<TransactionResponse>> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new TransactionModel()
            {
                TransactionNo = string.Empty,
                IsCompleted = request.AddTransactionRequest.IsCompleted,
                CompletedDate = request.AddTransactionRequest.CompletedDate,
                CreatedBy = null,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            var addTransaction = await _transactionService.AddTransaction(transaction);

            if(addTransaction.IsSuccess)
            {
                TransactionResponse transactionDTO = addTransaction.Value.Adapt<TransactionResponse>();

                return Result.Success(transactionDTO);
            }

            return Result.Failure<TransactionResponse>(addTransaction.Error);
        }
        #endregion
    }
}
