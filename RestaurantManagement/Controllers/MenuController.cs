using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        private readonly RestaurantContext _context;

        public MenuController(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menuItems = await _context.MenuItems.ToListAsync();
            var cartItems = await _context.CartItems.Include(c => c.MenuItem).ToListAsync();

            var viewModel = new MenuViewModel
            {
                MenuItems = menuItems,
                CartItems = cartItems
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            if (menuItem != null)
            {
                var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.MenuItemId == menuItemId);
                if (cartItem == null)
                {
                    cartItem = new CartItem { MenuItemId = menuItemId, Quantity = 1 };
                    _context.CartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity++;
                }

                await _context.SaveChangesAsync();
            }

            var cartItems = await _context.CartItems.Include(c => c.MenuItem).ToListAsync();
            return PartialView("_CartSummaryPartial", cartItems);
        }
    }
}
