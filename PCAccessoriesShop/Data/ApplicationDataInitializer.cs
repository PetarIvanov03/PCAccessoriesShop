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
        new Category { Name = "Headphones" },
        new Category { Name = "Keyboards" },
        new Category { Name = "Mice" },
        new Category { Name = "Monitors" },
        new Category { Name = "Microphones" }
    };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var rnd = new Random();
            var allProducts = new List<Product>();

            foreach (var category in categories)
            {
                for (int i = 1; i <= 10; i++)
                {
                    string name = "";
                    string description = "";
                    string imageUrl = "";

                    switch (category.Name)
                    {
                        case "Headphones":
                            name = $"HyperSound H{i}";
                            description = $"Premium over-ear headphones with noise cancellation and crystal-clear sound. Model H{i}.";
                            imageUrl = "/Images/ChatGPT_Headphones.png";
                            break;

                        case "Keyboards":
                            name = $"KeyPro Mechanical {i}";
                            description = $"Mechanical keyboard with RGB lighting and anti-ghosting keys. Model {i}.";
                            imageUrl = "/Images/ChatGPT_Keyboard.png";
                            break;

                        case "Mice":
                            name = $"SpeedMouse {i}X";
                            description = $"High-precision gaming mouse with adjustable DPI and ergonomic design.";
                            imageUrl = "/Images/ChatGPT_Mouse.png";
                            break;

                        case "Monitors":
                            name = $"VisionDisplay {i}Q";
                            description = $"27-inch QHD monitor with 144Hz refresh rate and ultra-slim bezels.";
                            imageUrl = "/Images/ChatGPT_Monitor.png";
                            break;

                        case "Microphones":
                            name = $"StudioMic V{i}";
                            description = $"Professional USB microphone ideal for streaming, podcasts, and studio recordings.";
                            imageUrl = "/Images/ChatGPT_Microphone.png";
                            break;
                    }

                    allProducts.Add(new Product
                    {
                        Name = name,
                        Description = description,
                        Price = rnd.Next(80, 400),
                        ImageUrl = imageUrl,
                        CategoryId = category.Id
                    });
                }
            }

            context.Products.AddRange(allProducts);
            context.SaveChanges();
        }

    }
}
