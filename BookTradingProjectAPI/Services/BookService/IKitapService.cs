using BookTradingProjectAPI.Dtos.RequestDto;
using BookTradingProjectAPI.Models.KitapModel;

namespace BookTradingProjectAPI.Services.BookService
{
    public interface IKitapService
    {
        Task<bool> KitapEkle(KitapEkleRequestDto model);
        Task<Kitap> GetByIdFromKitap(Guid id);
        Task<Kitap> KitapSil(Guid id);

    }
}
