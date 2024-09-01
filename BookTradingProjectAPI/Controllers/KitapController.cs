using BookTradingProjectAPI.Dtos.RequestDto;
using BookTradingProjectAPI.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        private readonly IKitapService _kitapService;

        public KitapController(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }
        [HttpPost("Kitapekle")]
        public async Task<IActionResult> KitapEkle(KitapEkleRequestDto model)
        {
            try
            {
                var result = await _kitapService.KitapEkle(model);

                return Ok(result);
            }
            catch (Exception e )
            {
                throw new Exception("Kitap ekleme basarisiz", e);
            }
        }
        [HttpGet("GetByIdFromKitap")]
        public async Task<IActionResult> GetByIdFromKitap(Guid id)
        {
            var result = await _kitapService.GetByIdFromKitap(id);
            return Ok(result);
        }
        
        [HttpDelete("KitapSil")]
        public async Task<IActionResult> KitapSil(Guid id)
        {
            var result = await _kitapService.KitapSil(id);
            return Ok(result);
        }
    }
}
