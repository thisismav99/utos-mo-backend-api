using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UtosMoBackendAPI.RepositoryManager
{
    public interface IRepository<TModel, TContext> 
        where TModel : class
        where TContext : DbContext
    {
        Task Add(TModel model);
        Task Update(TModel model);
        Task Delete(TModel model);
        Task<TModel?> GetBy(Expression<Func<TModel?, bool>> condition);
        Task<TModel?> GetById(Guid id);
        Task<List<TModel>?> GetAllBy(Expression<Func<TModel, bool>> condition);
        Task<List<TModel>?> GetAll();
        Task<bool> HasMatch(Expression<Func<TModel, bool>> condition);
        Task<TModel?> GetLatestBy<TKey>(Expression<Func<TModel, TKey>> column);
    }
}
