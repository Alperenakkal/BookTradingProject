using System.ComponentModel.DataAnnotations;

namespace BookTradingProjectAPI.Models
{
    public abstract class BaseModels
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OlusturlmaTarihi { get; set; } = DateTime.UtcNow;
        public DateTime GuncellemeTarihi { get; set; } = DateTime.UtcNow;

    }
}
