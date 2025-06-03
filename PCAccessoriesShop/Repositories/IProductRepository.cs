using Microsoft.AspNetCore.Mvc.Rendering;
using PCAccessoriesShop.Models;

namespace PCAccessoriesShop.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllWithCategoryAsync(string? category, string? sort);
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<bool> ExistsAsync(int id);
        Task<List<SelectListItem>> GetCategorySelectListAsync();
    }
}
