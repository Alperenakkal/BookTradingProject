namespace BookTradingProjectAPI.Models.KitapModel
{
    public enum Durum
    {
        Eski,
        Orta,
        Yeni
    }

    public enum Kategori
    {
        Kurgu,
        KurguDisi,
        Gizem,
        BilimKurgu,
        Fantastik,
        Biyografi,
        Tarih,
        Romantik,
        Gerilim,
        KisiselGelişim,
        Cocuk,
        Sanat,
        Felsefe,
        Dini,
        Bilim
    }
    public class Kitap : BaseModels
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
