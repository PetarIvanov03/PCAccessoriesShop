using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public interface ICartService
    {
        Task<List<CartItemViewModel>> GetCartItemsAsync(string userId);
        Task AddToCartAsync(int productId, string userId);
        Task RemoveFromCartAsync(int cartItemId);
    }

}
