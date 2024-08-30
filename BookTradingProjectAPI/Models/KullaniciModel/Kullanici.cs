

namespace BookTradingProjectAPI.Models.UserModels
{
    public enum CinsiyetTipi
    {
        Erkek =0,
        Kadın =1,
        Diğeri=2
    }
    public class Kullanici : BaseModels
    {
 
        public string KullaniciAdi { get; set; } = string.Empty;
        public string AdSoyad { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
        public string? SifreTekrari { get; set; }
        public string Mail { get; set; } = string.Empty;
        public string TelefonNo { get; set; } = string.Empty ;
        public string Sehir { get; set; } = string.Empty;
        public string Mahalle { get; set; } = string.Empty;
        public CinsiyetTipi Cinsiyet { get; set; }

    }
}
