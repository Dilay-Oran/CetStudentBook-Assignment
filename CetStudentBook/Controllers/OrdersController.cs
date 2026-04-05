using CetStudentBook.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CetStudentBook.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Identity!.Name;

            var orders = await _context.Orders
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Book)
        .Where(o => o.UserId == userId)
        .OrderByDescending(o => o.OrderDate)
        .ToListAsync();

            return View(orders);
        }
    }
}