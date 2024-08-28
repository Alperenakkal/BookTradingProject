using System.ComponentModel.DataAnnotations;

namespace BookTradingProjectAPI.Models
{
    public class BaseModels
    {
        [Key]
        public string Id { get; set; }
        public DateTime OlusturlmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }

    }
}
