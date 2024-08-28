using BookTradingProject.Models;
using System.Linq.Expressions;

namespace BookTradingProject.Repositories.IRepositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModels
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method);
        Task<TEntity> GetByIdAsync(string id);


    }
}
