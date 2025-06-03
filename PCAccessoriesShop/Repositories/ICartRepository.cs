using PCAccessoriesShop.Models;

namespace PCAccessoriesShop.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetCartItemsByUserAsync(string userId);
        Task<CartItem?> GetCartItemAsync(int productId, string userId);
        Task<CartItem?> GetByIdAsync(int id);
        Task AddAsync(CartItem item);
        Task UpdateAsync(CartItem item);
        Task DeleteAsync(CartItem item);
        Task SaveChangesAsync();
    }
}
