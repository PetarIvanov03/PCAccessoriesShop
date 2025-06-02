using System.ComponentModel.DataAnnotations;

namespace PCAccessoriesShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }

}
