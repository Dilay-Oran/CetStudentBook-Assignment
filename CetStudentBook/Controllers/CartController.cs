using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CetStudentBook.Data;
using CetStudentBook.Models;
using Microsoft.AspNetCore.Authorization;

namespace CetStudentBook.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Identity!.Name;
            var cartItems = await _context.CartItems
                .Include(c => c.Book)
                .Where(c => c.UserId == userId)
                .ToListAsync();
            return View("CartIndex", cartItems);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = User.Identity!.Name;
            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.BookId == id && c.UserId == userId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _context.CartItems.Add(new CartItem
                {
                    UserId = userId!,
                    BookId = id,
                    Quantity = 1
                });
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Purchase()
        {
            var userId = User.Identity!.Name;
            var cartItems = await _context.CartItems
                .Include(c => c.Book)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (cartItems.Any())
            {
                var order = new Order
                {
                    UserId = userId!,
                    OrderDate = DateTime.Now
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in cartItems)
                {
                    _context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order.Id,
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        Price = 0
                    });
                }
                _context.CartItems.RemoveRange(cartItems);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Orders");
        }
    }
}