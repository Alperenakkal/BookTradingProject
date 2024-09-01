using BookTradingProjectAPI.Dtos.KullaniciDto.RequestDto;
using BookTradingProjectAPI.Dtos.KullaniciDto.ResponseDto;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;
using BookTradingProjectAPI.Services.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace BookTradingProjectAPI.Services.KullaniciService
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IKullaniciReadRepository _kullaniciReadRepository;
        private readonly IKullaniciWriteRepository _kullaniciWriteRepository;
        private readonly ILogger<KullaniciService> _logger;
        private readonly ITokenHandler _tokenHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public KullaniciService(IKullaniciReadRepository kullaniciReadRepository, IKullaniciWriteRepository kullaniciWriteRepository, ILogger<KullaniciService> logger, ITokenHandler tokenHandler, IHttpContextAccessor httpContextAccessor)
        {
            _kullaniciReadRepository = kullaniciReadRepository;
            _kullaniciWriteRepository = kullaniciWriteRepository;
            _logger = logger;
            _tokenHandler = tokenHandler;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> KayitOlAsync(KayıtOlDtoRequest kayıtOlDto)
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
        public async Task<GirisYapResponseDto> GirisYapAsync(GirisYapDtoRequest loginRequest)
        {
            try
            {
                // Check if the input is valid
                if (string.IsNullOrEmpty(loginRequest.KullaniciAdiVeyaMail) || string.IsNullOrEmpty(loginRequest.Sifre))
                {
                    _logger.LogWarning("Login attempt with empty username/email or password.");
                    return new GirisYapResponseDto { Success = false }; // Invalid input
                }

                // Retrieve the user by username or email
                var user = await _kullaniciReadRepository.GetSingleAsync(u => u.KullaniciAdi == loginRequest.KullaniciAdiVeyaMail || u.Mail == loginRequest.KullaniciAdiVeyaMail);

                if (user == null)
                {
                    _logger.LogWarning("Login failed for {UsernameOrEmail}. User not found.", loginRequest.KullaniciAdiVeyaMail);
                    return new GirisYapResponseDto { Success = false }; // User not found
                }

                // Validate the password
                var passwordParts = user.Sifre.Split(':');
                var salt = passwordParts[0];
                var hash = passwordParts[1];
                var loginHash = ComputeSha256Hash(loginRequest.Sifre + salt);

                if (hash != loginHash)
                {
                    _logger.LogWarning("Login failed for {UsernameOrEmail}. Incorrect password.", loginRequest.KullaniciAdiVeyaMail);
                    return new GirisYapResponseDto { Success = false }; // Incorrect password
                }

                // Login successful
                _logger.LogInformation("User {Username} logged in successfully.", user.KullaniciAdi);

                // Create and return the token
                var token = _tokenHandler.CreateAccessToken(60); // 60 dakikalık geçerlilik süresi
                _logger.LogInformation("Generated token: {Token}", token.AccessToken);

                // HttpContext'i al
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    // Generate a secure cookie with the token
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddMinutes(60)
                    };

                    // Token'ı çereze ekle
                    httpContext.Response.Cookies.Append("AuthToken", token.AccessToken, cookieOptions);
                }

                // Token'ı yanıt gövdesine ekle
                return new GirisYapResponseDto
                {
                    Success = true,
                    Token = token.AccessToken
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in user {UsernameOrEmail}.", loginRequest.KullaniciAdiVeyaMail);
                return new GirisYapResponseDto { Success = false };
            }
        }
        public async Task<bool> CikisYap()
        {
            try
            {
                // Check if the context and request are available
                if (_httpContextAccessor.HttpContext == null)
                {
                    _logger.LogWarning("HTTP context is null during logout.");
                    return false;
                }

                // Remove the authentication cookie
                _httpContextAccessor.HttpContext.Response.Cookies.Delete("AuthToken");

                _logger.LogInformation("User logged out successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during logout.");
                return false;
            }
        }
        private Kullanici MapDtoToKullanici(KayıtOlDtoRequest kayıtOlDto)
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

