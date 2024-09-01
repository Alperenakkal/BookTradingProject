using BookTradingProjectAPI.Dtos.RequestDto;

namespace BookTradingProjectAPI.Services.BookService
{
    public interface IKitapService
    {
        Task<bool> KitapEkle(KitapEkleRequestDto model);
    }
}
