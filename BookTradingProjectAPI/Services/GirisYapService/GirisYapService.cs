using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Repositories.IRepositories;
using BookTradingProjectAPI.Services.LoginService;

namespace BookTradingProjectAPI.Services.RegisterService
{
    public class GirisYapService : IGirisYapService
    {
        private readonly IKullaniciReadRepository _kullaniciReadRepository;

        public GirisYapService(IKullaniciReadRepository kullaniciReadRepository)
        {
            _kullaniciReadRepository = kullaniciReadRepository;
        }

        public async Task<bool> GirisYapAsync(GirisYapDto girisYapDto)
        {
            // Kullanıcıyı kontrol et
            var user = await _kullaniciReadRepository.GetSingleAsync(k =>
                k.Mail == girisYapDto.Mail && k.Sifre == girisYapDto.Sifre);

            // Kullanıcı adı ve şifre doğruysa giriş başarılı
            return user != null;
        }
    }
}
