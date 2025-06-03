using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCAccessoriesShop.Services;
using PCAccessoriesShop.ViewModels;


namespace PCAccessoriesShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? category, string? sort)
        {
            var viewModel = await _service.GetProductListAsync(category, sort);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var viewModel = await _service.GetProductViewAsync(id.Value);
            return viewModel == null ? NotFound() : View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var form = await _service.GetProductFormForCreateAsync();
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = await _service.GetProductFormForCreateAsync().ContinueWith(t => t.Result.Categories);
                return View(viewModel);
            }

            await _service.CreateAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var form = await _service.GetProductFormForEditAsync(id.Value);
            return form == null ? NotFound() : View(form);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductFormViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                viewModel.Categories = await _service.GetProductFormForCreateAsync().ContinueWith(t => t.Result.Categories);
                return View(viewModel);
            }

            var success = await _service.UpdateAsync(id, viewModel);
            return success ? RedirectToAction(nameof(Index)) : NotFound();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var viewModel = await _service.GetProductViewAsync(id.Value);
            return viewModel == null ? NotFound() : View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
