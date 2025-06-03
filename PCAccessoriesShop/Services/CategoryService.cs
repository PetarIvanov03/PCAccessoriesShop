using PCAccessoriesShop.Models;
using PCAccessoriesShop.Repositories;
using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(MapToViewModel).ToList();
        }

        public async Task<CategoryViewModel?> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return category == null ? null : MapToViewModel(category);
        }

        public async Task CreateAsync(CategoryViewModel model)
        {
            var category = new Category { Name = model.Name };
            await _repository.AddAsync(category);
        }

        public async Task<bool> UpdateAsync(int id, CategoryViewModel model)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;

            category.Name = model.Name;
            await _repository.UpdateAsync(category);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                await _repository.DeleteAsync(category);
            }
        }

        private static CategoryViewModel MapToViewModel(Category category) =>
            new CategoryViewModel { Id = category.Id, Name = category.Name };
    }
}
