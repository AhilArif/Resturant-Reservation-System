using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
