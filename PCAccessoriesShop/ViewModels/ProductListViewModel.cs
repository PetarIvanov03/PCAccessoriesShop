using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PCAccessoriesShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public string? SelectedCategory { get; set; }
    }
}
