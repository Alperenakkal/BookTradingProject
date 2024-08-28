using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Models;
using BookTradingProjectAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookTradingProjectAPI.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseModels
    {
        private readonly VeriTabaniBaglami _baglam;

        public ReadRepository(VeriTabaniBaglami baglam)
        {
            _baglam = baglam;
        }

        public DbSet<TEntity> Table => _baglam.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
           var query = Table.AsQueryable();
            if (!tracking)
                 query.AsNoTracking();
                return query;
        }

        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                    query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if(!tracking)
                query.AsNoTracking();
            return query;
        }


    }
}
