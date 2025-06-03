using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCAccessoriesShop.Services;
using System.Security.Claims;

namespace PCAccessoriesShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var (success, message) = await _service.CheckoutAsync(userId);

            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction("Index", "Cart");
            }

            TempData["Success"] = "Your order was successfully placed!";
            return RedirectToAction("MyOrders");
        }

        public async Task<IActionResult> MyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = await _service.GetUserOrdersAsync(userId);
            return View(viewModel);
        }
    }

}
