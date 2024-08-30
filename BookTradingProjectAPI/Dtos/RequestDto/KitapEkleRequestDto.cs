using BookTradingProjectAPI.Models.KitapModel;

namespace BookTradingProjectAPI.Dtos.RequestDto
{
    public class KitapEkleRequestDto
    {
        public required string KitapAdi { get; set; }
        public string? Yazar { get; set; }
        public string? KitapResimUrl { get; set; }
        public Kategori Kategori { get; set; }
        public Durum Durum { get; set; }
        public bool Takas { get; set; }

        public required string KullaniciId { get; set; }

    }
}
