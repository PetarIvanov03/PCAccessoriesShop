using PCAccessoriesShop.Data;
using PCAccessoriesShop.Models;
using PCAccessoriesShop.Repositories;
using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        private readonly ApplicationDbContext _context;

        public CartService(ICartRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<List<CartItemViewModel>> GetCartItemsAsync(string userId)
        {
            var cartItems = await _repository.GetCartItemsByUserAsync(userId);
            return cartItems.Select(ci => new CartItemViewModel
            {
                Id = ci.Id,
                ProductName = ci.Product.Name,
                UnitPrice = ci.Product.Price,
                Quantity = ci.Quantity
            }).ToList();
        }

        public async Task AddToCartAsync(int productId, string userId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return;

            var existing = await _repository.GetCartItemAsync(productId, userId);
            if (existing != null)
            {
                existing.Quantity++;
                await _repository.UpdateAsync(existing);
            }
            else
            {
                var newItem = new CartItem
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = 1
                };
                await _repository.AddAsync(newItem);
            }
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var item = await _repository.GetByIdAsync(cartItemId);
            if (item != null)
            {
                await _repository.DeleteAsync(item);
            }
        }
    }

}
