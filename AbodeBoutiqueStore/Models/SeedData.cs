using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AbodeBoutiqueStore.Models
{
    // SeedData is run when the AbodeStore is compiled and launched
    // If no data exists in the Product database, then SeedData will populate it with sample data
    // This is for the purpose of testing and demonstrating the store
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Robot Vacuum Cleaner",
                    Description = "White Colour 2000W",
                    Category = "Home & Kitchen",
                    Price = 249,
                    Image = "/img/product/product1.png"
                },
                new Product
                {
                    Name = "Smart Watch",
                    Description = "Fashionable Android Smart Watch",
                    Category = "Electronics",
                    Price = 149,
                    Image = "/img/product/product2.png"
                },
                new Product
                {
                    Name = "Toy Dinosaurus",
                    Description = "Gift toy for kids",
                    Category = "Toys",
                    Price = 29,
                    Image = "/img/product/product3.png"
                },
                new Product
                {
                    Name = "Chair",
                    Description = "White colour chair",
                    Category = "Home Decor",
                    Price = 119,
                    Image = "/img/product/product4.png"
                },
                new Product
                {
                    Name = "Kettle",
                    Description = "1.25L metallic",
                    Category = "Kitchen",
                    Price = 49,
                    Image = "/img/product/product5.png"
                },
                new Product
                {
                    Name = "Kids Bedside Table",
                    Description = "2 draw bedside table",
                    Category = "Furniture",
                    Price = 299,
                    Image = "/img/product/product6.png"
                },
                new Product
                {
                    Name = "Tea Set",
                    Description = "Ceramic handmade tea set",
                    Category = "Kitchen",
                    Price = 199,
                    Image = "/img/product/product7.png"
                },
                new Product
                {
                    Name = "Watch",
                    Description = "Wrist watch",
                    Category = "Accessories",
                    Price = 129,
                    Image = "/img/product/product8.png"
                }
                );
                context.SaveChanges();
            }
        }
    }
}