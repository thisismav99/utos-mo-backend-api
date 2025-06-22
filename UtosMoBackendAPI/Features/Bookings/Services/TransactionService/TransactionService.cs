using CSharpFunctionalExtensions;
using UtosMoBackendAPI.Contexts;
using UtosMoBackendAPI.Features.Bookings.Utilities;
using UtosMoBackendAPI.Models.BookingModels;
using UtosMoBackendAPI.RepositoryManager;

namespace UtosMoBackendAPI.Features.Bookings.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        #region Variables
        private readonly IRepository<TransactionModel, BookingDbContext> _repository;
        #endregion

        #region Constructor
        public TransactionService(IRepository<TransactionModel, BookingDbContext> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<Result<TransactionModel>> AddTransaction(TransactionModel transaction)
        {
            var transactionExists = await _repository.HasMatch(x => x.IsCompleted == transaction.IsCompleted &&
                                                                    x.CompletedDate == transaction.CompletedDate &&
                                                                    x.BookingID == transaction.BookingID);

            if(transactionExists)
            {
                return Result.Failure<TransactionModel>(TransactionResultMessage.Exists);
            }

            var latestTransaction = await _repository.GetLatestBy(x => x.CreatedDate);

            if(latestTransaction is null)
            {
                return Result.Failure<TransactionModel>(TransactionResultMessage.LatestNotFound);
            }

            var newTransactionNo = TransactionUtility.TransactionNumberGenerator(latestTransaction.TransactionNo);

            if(string.IsNullOrEmpty(newTransactionNo))
            {
                return Result.Failure<TransactionModel>(TransactionResultMessage.UnableToGenerate);
            }

            transaction.TransactionNo = newTransactionNo;

            await _repository.Add(transaction);

            return Result.Success(transaction);
        }

        public async Task<Result<string>> DeleteTransaction(Guid transactionId)
        {
            var transaction = await _repository.GetById(transactionId);
            
            if(transaction is not null)
            {
                await _repository.Delete(transaction);

                return Result.Success(TransactionResultMessage.Removed);
            }

            return Result.Failure<string>(TransactionResultMessage.NotFound);
        }

        public async Task<Result<TransactionModel?>> GetTransactionById(Guid transactionId)
        {
            var transaction = await _repository.GetById(transactionId);

            if(transaction is not null)
            {
                return Result.Success<TransactionModel?>(transaction);
            }

            return Result.Failure<TransactionModel?>(TransactionResultMessage.NotFound);
        }

        public async Task<Result<string>> UpdateTransaction(TransactionModel transaction)
        {
            var isExactTransaction = await _repository.HasMatch(x => (x.ID == transaction.ID || x.TransactionNo == transaction.TransactionNo) &&
                                                                     x.IsCompleted == transaction.IsCompleted &&
                                                                     x.CompletedDate == transaction.CompletedDate &&
                                                                     x.BookingID == transaction.BookingID);

            if(isExactTransaction)
            {
                return Result.Failure<string>(TransactionResultMessage.NoChanges);
            }

            await _repository.Update(transaction);

            return Result.Success(TransactionResultMessage.Updated);
        }
        #endregion
    }
}
