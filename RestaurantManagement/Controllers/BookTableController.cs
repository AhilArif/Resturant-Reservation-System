using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantManagement.Controllers
{
    public class BookTableController : Controller
    {
        private readonly RestaurantContext _context;

        public BookTableController(RestaurantContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Confirmation), new { id = reservation.Id });
            }

            
            return View("Index", reservation);
        }

        
        public async Task<IActionResult> Confirmation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }
    }
}
