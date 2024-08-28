

namespace BookTradingProjectAPI.Models.UserModels
{
    public enum CinsiyetTipi
    {
        Erkek,
        Kadın,
        Diğeri
    }
    public class Kullanici : BaseModels
    {
        public string KullaniciAdi { get; set; }
        public string AdSoyad { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string TelefonNo { get; set; }
        public List<Adres> Adresler { get; set; }
        public CinsiyetTipi Cinsiyet { get; set; }

    }
}
