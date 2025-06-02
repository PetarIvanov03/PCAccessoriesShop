using Microsoft.EntityFrameworkCore;
using PCAccessoriesShop.Models;

namespace PCAccessoriesShop.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.Categories.Any() || context.Products.Any())
            {
                return;
            }

            var categories = new List<Category>
            {
                new Category { Name = "Слушалки" },
                new Category { Name = "Клавиатури" },
                new Category { Name = "Мишки" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var rnd = new Random();
            var allProducts = new List<Product>();

            foreach (var category in categories)
            {
                for (int i = 1; i <= 15; i++)
                {
                    allProducts.Add(new Product
                    {
                        Name = $"{category.Name} Модел {i}",
                        Description = $"Описание на {category.Name} Модел {i}",
                        Price = rnd.Next(50, 300),
                        Quantity = rnd.Next(5, 20),
                        ImageUrl = "/Images/ChatGPT_Headphones.png",
                        CategoryId = category.Id
                    });
                }
            }

            context.Products.AddRange(allProducts);
            context.SaveChanges();
        }
    }
}
