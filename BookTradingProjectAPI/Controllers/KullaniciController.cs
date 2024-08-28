using BookTradingProjectAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BookTradingProjectAPI.Controllers
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
  
    }
}
