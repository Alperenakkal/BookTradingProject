using BookTradingProjectAPI.Dtos.KullaniciDto;

namespace BookTradingProjectAPI.Services.RegisterService
{
    public interface IKayıtolService
    {
        Task<bool> KayıtOlAsync(KayıtOlDto kayıtOlDto);
    }
}
