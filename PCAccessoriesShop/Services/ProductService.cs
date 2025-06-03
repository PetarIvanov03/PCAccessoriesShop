using PCAccessoriesShop.Models;
using PCAccessoriesShop.Repositories;
using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductListViewModel> GetProductListAsync(string? category, string? sort)
        {
            var products = await _repository.GetAllWithCategoryAsync(category, sort);

            var productVMs = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category?.Name ?? "No category"
            }).ToList();

            var categories = await _repository.GetCategorySelectListAsync();

            return new ProductListViewModel
            {
                Products = productVMs,
                Categories = categories,
                SelectedCategory = category
            };
        }

        public async Task<ProductViewModel?> GetProductViewAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category?.Name ?? "No category"
            };
        }

        public async Task<ProductFormViewModel> GetProductFormForCreateAsync()
        {
            return new ProductFormViewModel
            {
                Categories = await _repository.GetCategorySelectListAsync()
            };
        }

        public async Task<ProductFormViewModel?> GetProductFormForEditAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductFormViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                Categories = await _repository.GetCategorySelectListAsync()
            };
        }

        public async Task CreateAsync(ProductFormViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };

            await _repository.AddAsync(product);
        }

        public async Task<bool> UpdateAsync(int id, ProductFormViewModel model)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.CategoryId = model.CategoryId;

            await _repository.UpdateAsync(product);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product != null)
            {
                await _repository.DeleteAsync(product);
            }
        }
    }

}
