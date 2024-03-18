using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Sprint1.Models;
using System.Linq;
using System.Security.Claims;

namespace Sprint1.Controllers
{
    
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IActionResult Index()
        {
            var userId = GetCurrentUserId();
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int bookId)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                // Handle the case where userId is null
                // You might redirect the user to a login page or return an error message
                return RedirectToAction("Login", "Account");
            }

            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                _context.SaveChanges(); // Save changes to get the cart's ID
            }

            var existingCartItem = cart?.CartItems.FirstOrDefault(item => item.BookId == bookId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                // Add the book to the cart
                var newCartItem = new CartItem { BookId = bookId, Quantity = 1 };
                cart.CartItems.Add(newCartItem);
                _context.SaveChanges(); // Save changes to persist the new cart item
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}
