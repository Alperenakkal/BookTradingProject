using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;

namespace BookTradingProjectAPI.Services.RegisterService
{
    public interface IKayitOlService
    {
      Task<bool> KayitOlAsync(Kullanici model);
    }
}
