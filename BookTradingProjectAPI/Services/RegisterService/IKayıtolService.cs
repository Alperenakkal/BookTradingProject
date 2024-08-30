using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;

namespace BookTradingProjectAPI.Services.RegisterService
{
    public interface IKayıtolService
    {
        Task<bool> KayıtOlAsync(Kullanici model);
    }
}
