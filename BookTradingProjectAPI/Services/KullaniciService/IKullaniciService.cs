using BookTradingProjectAPI.Dtos.KullaniciDto.RequestDto;
using BookTradingProjectAPI.Dtos.KullaniciDto.ResponseDto;
using BookTradingProjectAPI.Models.UserModels;

namespace BookTradingProjectAPI.Services.KullaniciService
{
    public interface IKullaniciService
    {
        Task<bool> KayitOlAsync(KayıtOlDtoRequest kayıtOlDto);
        Task<GirisYapResponseDto> GirisYapAsync(GirisYapDtoRequest loginRequest);
        Task<bool> CikisYap();
        Task<Kullanici> IdIleKullaniciCagir(string KullaniciAdi);
    }
}
