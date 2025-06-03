using PCAccessoriesShop.Models;
using PCAccessoriesShop.Repositories;
using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<(bool success, string? message)> CheckoutAsync(string userId)
        {
            var cartItems = await _repository.GetCartItemsByUserAsync(userId);
            if (!cartItems.Any())
                return (false, "Your cart is empty.");

            var order = new Order
            {
                UserId = userId,
                Items = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.Product.Price
                }).ToList()
            };

            await _repository.AddOrderAsync(order);
            await _repository.RemoveCartItemsAsync(cartItems);

            return (true, null);
        }

        public async Task<List<OrderViewModel>> GetUserOrdersAsync(string userId)
        {
            var orders = await _repository.GetOrdersByUserAsync(userId);

            return orders.Select(o => new OrderViewModel
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                Items = o.Items.Select(i => new OrderItemViewModel
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    ImageUrl = i.Product.ImageUrl
                }).ToList()
            }).ToList();
        }
    }

}
