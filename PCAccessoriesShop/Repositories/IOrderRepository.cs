using PCAccessoriesShop.Models;

namespace PCAccessoriesShop.Repositories
{
    public interface IOrderRepository
    {
        Task<List<CartItem>> GetCartItemsByUserAsync(string userId);
        Task AddOrderAsync(Order order);
        Task RemoveCartItemsAsync(List<CartItem> items);
        Task<List<Order>> GetOrdersByUserAsync(string userId);
    }

}
