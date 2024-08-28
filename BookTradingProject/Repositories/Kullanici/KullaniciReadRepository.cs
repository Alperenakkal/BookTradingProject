using BookTradingProject.Data.Context;
using BookTradingProject.Models.UserModels;
using BookTradingProject.Repositories.IRepositories;

namespace BookTradingProject.Repositories
{
    public class KullaniciReadRepository : ReadRepository<Kullanici>, IKullaniciReadRepository
    {
        public KullaniciReadRepository(VeriTabaniBaglami baglam) : base(baglam)
        {
        }
    }
}
