using BookTradingProjectAPI.Models;

namespace BookTradingProjectAPI.Repositories.IRepositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModels
    {
        Task<bool> AddSingleAsync(TEntity model);
        Task<bool> AddManyAsync(List<TEntity> datas);
        bool RemoveSingle(TEntity model);
        bool RemoveMany(List<TEntity> datas);
        bool Update(TEntity model);
        Task<int> SaveAsync();


    }
}
