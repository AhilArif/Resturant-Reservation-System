using System.Collections.Generic;

namespace RestaurantManagement.Models
{
    public class MenuViewModel
    {
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
