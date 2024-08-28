using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Models.KitapModel;
using BookTradingProjectAPI.Repositories.IRepositories;

namespace BookTradingProjectAPI.Repositories
{
    public class KitapReadRepository : ReadRepository<Kitap>, IKitapReadRepository
    {
        public KitapReadRepository(VeriTabaniBaglami baglam) : base(baglam)
        {
        }
    }
}
