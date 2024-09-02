using Azure.Core;
using BookTradingProjectAPI.Dtos.RequestDto;
using BookTradingProjectAPI.Models.KitapModel;
using BookTradingProjectAPI.Repositories.IRepositories;

namespace BookTradingProjectAPI.Services.BookService
{
    public class KitapService : IKitapService
    {
        private readonly IKitapReadRepository _kitapReadRepository;
        private readonly IKitapWriteRepository _kitapWriteRepository;

        public KitapService(IKitapReadRepository kitapReadRepository, IKitapWriteRepository kitapWriteRepository)
        {
            _kitapReadRepository = kitapReadRepository;
            _kitapWriteRepository = kitapWriteRepository;
        }


        public async Task<bool> KitapEkle(KitapEkleRequestDto model)
        {
            try
            {


                Kitap kitap = new Kitap
                {
                    KitapAdi = model.KitapAdi,
                    KullaniciId = model.KullaniciId,
                    Durum = model.Durum,
                    KitapResimUrl = model.KitapResimUrl,
                    Takas = model.Takas,
                    Yazar = model.Yazar,
                    Kategori = model.Kategori,
                    OlusturlmaTarihi = DateTime.Now

                };
                var isAdded = await _kitapWriteRepository.AddSingleAsync(kitap);
                if (isAdded == false) { return false; }
                await _kitapWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception("Kitap ekleme işlemi basarizi", e);
            }


        }
        public async Task<Kitap> GetByIdFromKitap(string id)
        {
            Guid Id = new Guid(id);
            Kitap kitap = await _kitapReadRepository.GetByIdAsync(Id);
            return kitap;

        }
        public async Task<bool> KitapSil(string id)
        {
            try
            {
                Guid Id = new Guid(id);
                Kitap kitap = await _kitapReadRepository.GetByIdAsync(Id);
                var isDeleted = _kitapWriteRepository.RemoveSingle(kitap);
                if (isDeleted == false) { return false; }
                await _kitapWriteRepository.SaveAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception("Kitap silme islemi basarisiz", e);
            }


        }
    }
}
