using BookTradingProject.Data.Context;
using BookTradingProject.Models;
using BookTradingProject.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookTradingProject.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseModels
    {
        private readonly VeriTabaniBaglami _baglam;

        public WriteRepository(VeriTabaniBaglami baglam)
        {
            _baglam = baglam;
        }

        public DbSet<TEntity> Table => _baglam.Set<TEntity>();


        public async Task<bool> AddManyAsync(List<TEntity> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task<bool> AddSingleAsync(TEntity model)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public bool RemoveMany(List<TEntity> datas)
        {
          Table.RemoveRange(datas);
          return true;
            
        }

        public bool RemoveSingle(TEntity model)
        {
          EntityEntry<TEntity> entityEntry = Table.Remove(model);
          return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
            => await _baglam.SaveChangesAsync();
            
        

        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
