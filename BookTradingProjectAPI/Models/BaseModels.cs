using System.ComponentModel.DataAnnotations;

namespace BookTradingProjectAPI.Models
{
    public abstract class BaseModels
    {
        
        public string Id { get; set; } 
        public DateTime OlusturlmaTarihi { get; set; } = DateTime.UtcNow;
        public DateTime GuncellemeTarihi { get; set; } = DateTime.UtcNow;

    }
}
