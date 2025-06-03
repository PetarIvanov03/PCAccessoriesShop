using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel?> GetByIdAsync(int id);
        Task CreateAsync(CategoryViewModel model);
        Task<bool> UpdateAsync(int id, CategoryViewModel model);
        Task DeleteAsync(int id);
    }
}
