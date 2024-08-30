using System.ComponentModel.DataAnnotations;

namespace BookTradingProjectAPI.Models
{
    public abstract class BaseModels
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OlusturlmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }

    }
}
