using System.ComponentModel.DataAnnotations;

namespace PCAccessoriesShop.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category name."), MaxLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = null!;
    }

}
