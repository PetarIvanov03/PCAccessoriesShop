using Microsoft.AspNetCore.Mvc.Rendering;

namespace PCAccessoriesShop.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }

    }
}
