using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Services.KullaniciService;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpPost("KayitOl")]
        public async Task<IActionResult> KayıtOl(KayıtOlDto kayıtOlDto)
        {
            var result = await _kullaniciService.KayitOlAsync(kayıtOlDto);
            if (result)
            {
                return Ok("Kayıt başarılı.");
            }

            return BadRequest("Kayıt başarısız.");
        
        }
        [HttpPost("GirisYap")]
        public async Task<IActionResult> GirisYap([FromBody] GirisYapDto girisYapDto)
        {
            if (girisYapDto == null)
            {
                return BadRequest("Geçersiz giriş bilgileri."); // 400 Bad Request if DTO is null
            }

            // Call the service to authenticate the user
            var loginSuccess = await _kullaniciService.GirisYapAsync(girisYapDto);

            if (loginSuccess)
            {
                // Return 200 OK if login is successful
                return Ok("Giriş başarılı.");
            }
            else
            {
                // Return 401 Unauthorized if login fails
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");
            }
        }
    }
}
