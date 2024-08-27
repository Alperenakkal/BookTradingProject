

namespace BookTradingProject.Models.UserModels
{
    public class Kullanici: BaseModels
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string TelefonNo { get; set; }
        public List<Adres> Adresler { get; set; }

    }
}
