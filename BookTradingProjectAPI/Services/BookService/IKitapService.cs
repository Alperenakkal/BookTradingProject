using BookTradingProjectAPI.Dtos.RequestDto;
using BookTradingProjectAPI.Models.KitapModel;

namespace BookTradingProjectAPI.Services.BookService
{
    public interface IKitapService
    {
        Task<bool> KitapEkle(KitapEkleRequestDto model);
        Task<Kitap> GetByIdFromKitap(string id);
        Task<bool> KitapSil(string id);

    }
}
