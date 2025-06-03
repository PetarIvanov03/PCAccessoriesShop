using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCAccessoriesShop.Services;
using System.Security.Claims;

namespace PCAccessoriesShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items = await _service.GetCartItemsAsync(userId);
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _service.AddToCartAsync(productId, userId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _service.RemoveFromCartAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
