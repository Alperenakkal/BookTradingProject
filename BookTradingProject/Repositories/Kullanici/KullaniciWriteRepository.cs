using BookTradingProject.Data.Context;
using BookTradingProject.Models.UserModels;
using BookTradingProject.Repositories.IRepositories;

namespace BookTradingProject.Repositories
{
    public class KullaniciWriteRepository : WriteRepository<Kullanici>, IKullaniciWriteRepository
    {
        public KullaniciWriteRepository(VeriTabaniBaglami baglam) : base(baglam)
        {
        }
    }
}
