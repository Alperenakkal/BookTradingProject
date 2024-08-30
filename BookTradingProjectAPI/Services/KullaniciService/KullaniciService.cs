using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;
using System.Security.Cryptography;
using System.Text;

namespace BookTradingProjectAPI.Services.KullaniciService
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IKullaniciReadRepository _kullaniciReadRepository;
        private readonly IKullaniciWriteRepository _kullaniciWriteRepository;
        private readonly ILogger<KullaniciService> _logger;

        public KullaniciService(IKullaniciReadRepository kullaniciReadRepository, IKullaniciWriteRepository kullaniciWriteRepository, ILogger<KullaniciService> logger)
        {
            _kullaniciReadRepository = kullaniciReadRepository;
            _kullaniciWriteRepository = kullaniciWriteRepository;
            _logger = logger;
        }

        public async Task<bool> KayitOlAsync(KayıtOlDto kayıtOlDto)
        {
            try
            {
                if (kayıtOlDto == null)
                {
                    _logger.LogWarning("User registration attempt with null user.");
                    return false;
                }

                if (kayıtOlDto.Sifre != kayıtOlDto.SifreTekrari)
                {
                    _logger.LogWarning("Passwords do not match for user {UserName}.", kayıtOlDto.KullaniciAdi);
                    return false;
                }

                // Check if the user already exists
                var existingUserByUsername = await _kullaniciReadRepository.GetSingleAsync(u => u.KullaniciAdi == kayıtOlDto.KullaniciAdi);
                var existingUserByEmail = await _kullaniciReadRepository.GetSingleAsync(u => u.Mail == kayıtOlDto.Mail);

                if (existingUserByUsername != null || existingUserByEmail != null)
                {
                    _logger.LogWarning("User with username {UserName} or email {Email} already exists.", kayıtOlDto.KullaniciAdi, kayıtOlDto.Mail);
                    return false;
                }

                // Map DTO to domain model
                var kullanici = MapDtoToKullanici(kayıtOlDto);

                // Add the new user
                await _kullaniciWriteRepository.AddSingleAsync(kullanici);
                await _kullaniciWriteRepository.SaveAsync();

                _logger.LogInformation("User {UserName} registered successfully.", kayıtOlDto.KullaniciAdi);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering user {UserName}.", kayıtOlDto.KullaniciAdi);
                return false;
            }
        }
        public async Task<bool> GirisYapAsync(GirisYapDto girisYapDto)
        {
            try
            {
                if (girisYapDto == null || string.IsNullOrEmpty(girisYapDto.KullaniciAdiVeyaMail) || string.IsNullOrEmpty(girisYapDto.Sifre))
                {
                    _logger.LogWarning("Login attempt with empty username/email or password.");
                    return false;
                }

                // Fetch the user based on username or email
                var kullanici = await _kullaniciReadRepository.GetSingleAsync(u => u.KullaniciAdi == girisYapDto.KullaniciAdiVeyaMail || u.Mail == girisYapDto.KullaniciAdiVeyaMail);

                if (kullanici == null)
                {
                    _logger.LogWarning("Login failed for {KullaniciAdiVeyaMail}. User not found.", girisYapDto.KullaniciAdiVeyaMail);
                    return false;
                }

                // Check the hashed password
                var sifreParts = kullanici.Sifre.Split(':');
                if (sifreParts.Length != 2)
                {
                    _logger.LogError("Stored password format is incorrect for user {KullaniciAdiVeyaMail}.", girisYapDto.KullaniciAdiVeyaMail);
                    return false;
                }

                var salt = sifreParts[0];
                var storedHash = sifreParts[1];
                var loginHash = ComputeSha256Hash(girisYapDto.Sifre + salt);

                if (storedHash != loginHash)
                {
                    _logger.LogWarning("Login failed for {KullaniciAdiVeyaMail}. Incorrect password.", girisYapDto.KullaniciAdiVeyaMail);
                    return false;
                }

                // Successful login
                _logger.LogInformation("User {KullaniciAdi} logged in successfully.", kullanici.KullaniciAdi);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in user {KullaniciAdiVeyaMail}.", girisYapDto.KullaniciAdiVeyaMail);
                return false;
            }
        }

        private Kullanici MapDtoToKullanici(KayıtOlDto kayıtOlDto)
        {
            return new Kullanici
            {
                Id = Guid.NewGuid(),
                KullaniciAdi = kayıtOlDto.KullaniciAdi,
                AdSoyad = kayıtOlDto.AdSoyad,
                TelefonNo = kayıtOlDto.TelefonNo,
                Sehir = kayıtOlDto.Sehir,
                Mahalle = kayıtOlDto.Mahalle,
                Cinsiyet = kayıtOlDto.cinsiyet,
                Mail = kayıtOlDto.Mail,
                Sifre = HashPassword(kayıtOlDto.Sifre),
            };
        }

        private string HashPassword(string password)
        {
            var salt = GenerateSalt();
            var hash = ComputeSha256Hash(password + salt);
            return $"{salt}:{hash}";
        }

        private string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Convert.ToBase64String(bytes);
            }
        }
        

    }
}

