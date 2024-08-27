using System.ComponentModel.DataAnnotations;

namespace BookTradingProject.Models.UserModels
{
    public class Adres
    {
        [Key]
        public string Şehir { get; set; }
        public string Mahalle { get; set; }
        public string Cadde { get; set; }
        public string Sokak { get; set; }
        public int SokakNo { get; set; } 
        public int DaireNo { get; set; }
    }
}
