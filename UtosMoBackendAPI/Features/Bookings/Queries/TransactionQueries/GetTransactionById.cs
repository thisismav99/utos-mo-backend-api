using CSharpFunctionalExtensions;
using Mapster;
using MediatR;
using UtosMoBackendAPI.Features.Bookings.DTO.Transactions;
using UtosMoBackendAPI.Features.Bookings.Services.TransactionService;

namespace UtosMoBackendAPI.Features.Bookings.Queries.TransactionQueries
{
    public record class GetTransactionByIdQuery(Guid TransactionId) : IRequest<Result<TransactionResponse>>;

    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, Result<TransactionResponse>>
    {
        #region Variable
        private readonly ITransactionService _transactionService;
        #endregion

        #region Constructor
        public GetTransactionByIdHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        #endregion

        #region Method
        public async Task<Result<TransactionResponse>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionService.GetTransactionById(request.TransactionId);
            
            if(transaction.IsSuccess)
            {
                TransactionResponse transactionDTO = transaction.Value.Adapt<TransactionResponse>();

                return Result.Success(transactionDTO);
            }

            return Result.Failure<TransactionResponse>(transaction.Error);
        }
        #endregion
    }
}
