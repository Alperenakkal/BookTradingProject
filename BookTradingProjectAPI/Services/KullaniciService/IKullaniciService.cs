using BookTradingProjectAPI.Dtos.KullaniciDto.RequestDto;
using BookTradingProjectAPI.Dtos.KullaniciDto.ResponseDto;

namespace BookTradingProjectAPI.Services.KullaniciService
{
    public interface IKullaniciService
    {
        Task<bool> KayitOlAsync(KayıtOlDtoRequest kayıtOlDto);
        Task<GirisYapResponseDto> GirisYapAsync(GirisYapDtoRequest loginRequest);
        Task<bool> CikisYap();
    }
}
