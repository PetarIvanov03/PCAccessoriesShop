using PCAccessoriesShop.ViewModels;

namespace PCAccessoriesShop.Services
{
    public interface IProductService
    {
        Task<ProductListViewModel> GetProductListAsync(string? category, string? sort);
        Task<ProductViewModel?> GetProductViewAsync(int id);
        Task<ProductFormViewModel?> GetProductFormForEditAsync(int id);
        Task<ProductFormViewModel> GetProductFormForCreateAsync();
        Task CreateAsync(ProductFormViewModel model);
        Task<bool> UpdateAsync(int id, ProductFormViewModel model);
        Task DeleteAsync(int id);
    }

}
