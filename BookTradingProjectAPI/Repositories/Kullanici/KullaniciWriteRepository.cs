using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.BaseRepositories;
using BookTradingProjectAPI.Repositories.IRepositories;

namespace BookTradingProjectAPI.Repositories
{
    public class KullaniciWriteRepository : WriteRepository<Kullanici>, IKullaniciWriteRepository
    {
        public KullaniciWriteRepository(VeriTabaniBaglami baglam) : base(baglam)
        {
        }
    }
}
