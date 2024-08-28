using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;

namespace BookTradingProjectAPI.Repositories
{
    public class KullaniciReadRepository : ReadRepository<Kullanici>, IKullaniciReadRepository
    {
        public KullaniciReadRepository(VeriTabaniBaglami baglam) : base(baglam)
        {
        }
    }
}
