using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UtosMoBackendAPI.RepositoryManager
{
    public class Repository<TModel, TContext> : IRepository<TModel, TContext>
        where TModel : class
        where TContext : DbContext
    {
        #region Variables
        private readonly TContext _context;
        private readonly DbSet<TModel> _dbSetModel;
        #endregion

        #region Constructor
        public Repository(TContext context)
        {
            _context = context;
            _dbSetModel = _context.Set<TModel>();
        }
        #endregion

        #region Methods
        public async Task Add(TModel model)
        {
            await _dbSetModel.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TModel model)
        {
            _dbSetModel.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TModel>?> GetAll()
        {
            return await _dbSetModel.ToListAsync();
        }

        public async Task<List<TModel>?> GetAllBy(Expression<Func<TModel, bool>> condition)
        {
            return await _dbSetModel.Where(condition).ToListAsync();
        }

        public async Task<TModel?> GetBy(Expression<Func<TModel?, bool>> condition)
        {
            return await _dbSetModel.Where(condition).FirstOrDefaultAsync();
        }

        public async Task<TModel?> GetById(Guid id)
        {
            return await _dbSetModel.FindAsync(id);
        }

        public async Task<TModel?> GetLatestBy<TKey>(Expression<Func<TModel, TKey>> column)
        {
            return await _dbSetModel.OrderByDescending(column).FirstOrDefaultAsync();
        }

        public async Task<bool> HasMatch(Expression<Func<TModel, bool>> condition)
        {
            return await _dbSetModel.AnyAsync(condition);
        }

        public async Task Update(TModel model)
        {
            _dbSetModel.Attach(model);
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
