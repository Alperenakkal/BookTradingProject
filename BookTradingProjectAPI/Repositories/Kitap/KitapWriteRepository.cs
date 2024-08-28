using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Models.KitapModel;
using BookTradingProjectAPI.Repositories.IRepositories;



namespace BookTradingProjectAPI.Repositories
{
    public class KitapWriteRepository : WriteRepository<Kitap>,IKitapWriteRepository
    {
        public KitapWriteRepository(VeriTabaniBaglami baglam) : base(baglam)
        {
        }
    }
}
