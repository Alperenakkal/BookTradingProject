using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;

namespace BookTradingProjectAPI.Services.RegisterService
{
    public class KayıtolService : IKayıtolService
    {
        private readonly IKullaniciReadRepository _kullaniciReadRepository;
        private readonly IKullaniciWriteRepository _kullaniciWriteRepository;

        public KayıtolService(IKullaniciReadRepository kullaniciReadRepository, IKullaniciWriteRepository kullaniciWriteRepository)
        {
            _kullaniciReadRepository = kullaniciReadRepository;
            _kullaniciWriteRepository = kullaniciWriteRepository;
        }

        public async Task<bool> KayıtOlAsync(KayıtOlDto kayıtOlDto)
        {
            // Şifre doğrulama
            if (kayıtOlDto.Sifre != kayıtOlDto.SifreTekrari)
            {
                return false;
            }

            // Kullanıcı adı kontrolü
            var existingUser = await _kullaniciReadRepository.GetSingleAsync(k => k.KullaniciAdi == kayıtOlDto.KullaniciAdi);
            if (existingUser != null)
            {
                return false; // Kullanıcı adı zaten kullanılıyor
            }

            // DTO'dan Kullanici modelini manuel olarak oluşturma
            var kullanici = new Kullanici
            {
                KullaniciAdi = kayıtOlDto.KullaniciAdi,
                AdSoyad = kayıtOlDto.AdSoyad,
                Sifre = kayıtOlDto.Sifre,
                Mail = kayıtOlDto.Mail,
                Cinsiyet = kayıtOlDto.cinsiyet,
                TelefonNo = kayıtOlDto.TelefonNo,
                Adresler = kayıtOlDto.Adresler
            };

            // Kullanıcıyı veritabanına ekleme
            var isAdded = await _kullaniciWriteRepository.AddSingleAsync(kullanici);
            if (!isAdded)
            {
                return false;
            }

            // Değişiklikleri kaydetme
            await _kullaniciWriteRepository.SaveAsync();

            return true;
        }
    }
}