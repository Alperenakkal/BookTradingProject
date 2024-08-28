using BookTradingProjectAPI.Dtos.KullaniciDto;
using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;
using BookTradingProjectAPI.Services.RegisterService;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKayıtolService _kayıtolService;

        public KullaniciController(IKayıtolService kayıtolService)
        {
            _kayıtolService = kayıtolService;
        }
        //[HttpPost("kayitol")]
        //public async Task<IActionResult> KayıtOl(KayıtOlDto kayıtOlDto)
        //{
        //    var result = await _kayıtolService.KayıtOlAsync(kayıtOlDto);
        //    if (result)
        //    {
        //        return Ok("Kayıt başarılı.");
        //    }

        //    return BadRequest("Kayıt başarısız.");
        //}
    }
}
