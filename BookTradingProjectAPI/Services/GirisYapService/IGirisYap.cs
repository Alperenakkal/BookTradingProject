using System.Threading.Tasks;
using BookTradingProjectAPI.Dtos.KullaniciDto;

namespace BookTradingProjectAPI.Services.LoginService
{
    public interface IGirisYapService
    {
        Task<bool> GirisYapAsync(GirisYapDto girisYapDto);
    }
}
