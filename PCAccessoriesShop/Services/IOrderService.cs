using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public interface IOrderService
    {
        Task<(bool success, string? message)> CheckoutAsync(string userId);
        Task<List<OrderViewModel>> GetUserOrdersAsync(string userId);
    }

}
