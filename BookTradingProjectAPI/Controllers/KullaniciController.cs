using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;
using BookTradingProjectAPI.Services.LoginService;
using BookTradingProjectAPI.Services.RegisterService;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKayitOlService _kayıtolService;
        private readonly IGirisYapService _girisYapService;

        public KullaniciController(IKayitOlService kayıtolService, IGirisYapService girisYapService)
        {
            _kayıtolService = kayıtolService;
            _girisYapService = girisYapService;
        }
        [HttpPost("kayitol")]
        public async Task<IActionResult> KayıtOl(Kullanici model)
        {
            var result = await _kayıtolService.KayitOlAsync(model);
            if (result)
            {
                return Ok("Kayıt başarılı.");
            }

            return BadRequest("Kayıt başarısız.");
        
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap([FromBody] GirisYapDto girisYapDto)
        {
            if (girisYapDto == null)
            {
                return BadRequest("Geçersiz giriş bilgileri."); // 400 Bad Request if DTO is null
            }

            // Call the service to authenticate the user
            var loginSuccess = await _girisYapService.GirisYapAsync(girisYapDto);

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
