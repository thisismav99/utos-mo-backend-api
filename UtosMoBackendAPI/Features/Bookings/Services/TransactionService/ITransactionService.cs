using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Features.Bookings.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<Result<TransactionModel>> AddTransaction(TransactionModel transaction);
        Task<Result<string>> UpdateTransaction(TransactionModel transaction);
        Task<Result<string>> DeleteTransaction(Guid transactionId);
        Task<Result<TransactionModel?>> GetTransactionById(Guid transactionId);
    }
}
