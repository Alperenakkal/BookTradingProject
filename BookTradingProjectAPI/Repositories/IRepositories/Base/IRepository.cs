using BookTradingProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradingProjectAPI.Repositories.IRepositories
{
    public interface IRepository<TEntity> where TEntity : BaseModels
    {
        DbSet<TEntity> Table { get; }
    }
}
