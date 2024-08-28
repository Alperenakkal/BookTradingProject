using BookTradingProjectAPI.Models.UserModels;
using BookTradingProjectAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        readonly private IKullaniciWriteRepository _kullaniciWriteRepository;
        readonly private IKullaniciReadRepository _kullaniciReadRepository;

        public KullaniciController(IKullaniciWriteRepository kullaniciWriteRepository, IKullaniciReadRepository kullaniciReadRepository)
        {
            _kullaniciWriteRepository = kullaniciWriteRepository;
            _kullaniciReadRepository = kullaniciReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //  _kullaniciWriteRepository.AddManyAsync(new()
            //  {
            //       new() { Id =Guid.NewGuid().ToString(),
            //          KullaniciAdi = "HalukAyt",
            //          Mail = "halukaytis@gmail.com",
            //          Sifre = "123456789",
            //          TelefonNo = "05435779604",
            //          Cinsiyet = 0,
            //          GuncellemeTarihi =DateTime.UtcNow,
            //          OlusturlmaTarihi=DateTime.UtcNow},
            //      new() { Id =Guid.NewGuid().ToString(),
            //          KullaniciAdi = "HaukAyt",
            //          Mail = "halukatis@gmail.com",
            //          Sifre = "123456789",
            //          TelefonNo = "05435779804",
            //          Cinsiyet = 0,
            //          GuncellemeTarihi =DateTime.UtcNow,
            //          OlusturlmaTarihi=DateTime.UtcNow},

            //  });
            //await _kullaniciWriteRepository.SaveAsync();

      Kullanici k =      await _kullaniciReadRepository.GetByIdAsync("6832b347-bab3-41f5-8e42-20d01183d67c",false);
            k.KullaniciAdi = "Mehmet";
            await _kullaniciWriteRepository.SaveAsync();
        }
    }
}
