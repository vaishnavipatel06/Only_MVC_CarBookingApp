using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBookingApp.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [ForeignKey("Car")] 
        public int CarId { get; set; }
        public int StockQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
