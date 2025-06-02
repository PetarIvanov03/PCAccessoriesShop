using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCAccessoriesShop.Data;
using PCAccessoriesShop.Models;
using PCAccessoriesShop.ViewModels;
using System.Security.Claims;

namespace PCAccessoriesShop.Controllers
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = await _context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();

            var viewModel = cartItems.Select(MapToViewModel).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var existing = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                var cartItem = new CartItem
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private static CartItemViewModel MapToViewModel(CartItem ci)
        {
            return new CartItemViewModel
            {
                Id = ci.Id,
                ProductName = ci.Product.Name,
                UnitPrice = ci.Product.Price,
                Quantity = ci.Quantity
            };
        }
    }
}
