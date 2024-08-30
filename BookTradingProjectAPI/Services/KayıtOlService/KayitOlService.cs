using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;

namespace BookTradingProjectAPI.Services.RegisterService
{
    public class KayitolService : IKayitOlService
    {
        private readonly IKullaniciReadRepository _kullaniciReadRepository;
        private readonly IKullaniciWriteRepository _kullaniciWriteRepository;

        public KayitolService(IKullaniciReadRepository kullaniciReadRepository, IKullaniciWriteRepository kullaniciWriteRepository)
        {
            _kullaniciReadRepository = kullaniciReadRepository;
            _kullaniciWriteRepository = kullaniciWriteRepository;
        }

        public async Task<bool> KayitOlAsync(Kullanici model)
        {
            {
                // Şifre doğrulama
                if (model.Sifre != model.SifreTekrari)
                {
                    return false;
                }

                // Kullanıcı adı kontrolü
                var existingUser = await _kullaniciReadRepository.GetSingleAsync(k => k.KullaniciAdi == model.KullaniciAdi);
                if (existingUser != null)
                {
                    return false; // Kullanıcı adı zaten kullanılıyor
                }

                // DTO'dan Kullanici modelini manuel olarak oluşturma
                var kullanici = new Kullanici
                {
                    KullaniciAdi = model.KullaniciAdi,
                    AdSoyad = model.AdSoyad,
                    Sifre = model.Sifre,
                    Mail = model.Mail,
                    Cinsiyet = model.Cinsiyet,
                    TelefonNo = model.TelefonNo,
                    Adresler = model.Adresler
                };

                // Kullanıcıyı veritabanına ekleme
                var isAdded =  _kullaniciWriteRepository.AddSingleAsync(kullanici);
                if (!await isAdded)
                {
                    return false;
                }

                // Değişiklikleri kaydetme
                await _kullaniciWriteRepository.SaveAsync();

                return true;
            }
        }      
    }
}