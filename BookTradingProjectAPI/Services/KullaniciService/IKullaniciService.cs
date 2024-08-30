using BookTradingProjectAPI.Dtos.KullaniciDto;

namespace BookTradingProjectAPI.Services.KullaniciService
{
    public interface IKullaniciService
    {
        Task<bool> KayitOlAsync(KayıtOlDto kayıtOlDto);
        Task<bool> GirisYapAsync(GirisYapDto girisYapDto);
    }
}
