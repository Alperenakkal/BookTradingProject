using BookTradingProjectAPI.Dtos.KullaniciDto.RequestDto;
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
        public async Task<IActionResult> KayıtOl(KayıtOlDtoRequest kayıtOlDto)
        {
            var result = await _kullaniciService.KayitOlAsync(kayıtOlDto);
            if (result)
            {
                return Ok("Kayıt başarılı.");
            }

            return BadRequest("Kayıt başarısız.");
        
        }
        [HttpPost("GirisYap")]
        public async Task<IActionResult> GirisYap([FromBody] GirisYapDtoRequest loginRequest)
        {
            var result = await _kullaniciService.GirisYapAsync(loginRequest);
            if (result.Success)
            {
                return Ok(result); // Başarılıysa Token Döndür
            }
            return Unauthorized(); 
        }
        [HttpPost("CikisYap")]
        public async Task<IActionResult> CikisYap()
        {
            var result = await _kullaniciService.CikisYap();

            if (result)
                return Ok(new { message = "Başarıyla Çıkış Yapıldı." });

            return BadRequest(new { message = "Hata..." });
        }
    }
}
