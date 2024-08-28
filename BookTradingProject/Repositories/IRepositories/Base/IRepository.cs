using BookTradingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTradingProject.Repositories.IRepositories
{
    public interface IRepository<TEntity> where TEntity : BaseModels
    {
        DbSet<TEntity> Table { get; }
    }
}
