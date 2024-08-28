using BookTradingProjectAPI.Models.KitapModel;

namespace BookTradingProjectAPI.Dtos.ResponseDto
{
    public class KitapEkleResponseDto
    {
        public  required string DurumKodu { get; set; }
        public required string Sonuç { get; set; }

      
    }
}
