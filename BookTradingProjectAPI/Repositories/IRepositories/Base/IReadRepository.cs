using BookTradingProjectAPI.Models;
using System.Linq.Expressions;

namespace BookTradingProjectAPI.Repositories.IRepositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModels
    {
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetByIdAsync(Guid id, bool tracking = true);


    }
}
