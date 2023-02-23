using ProductDemoApp.Models;

namespace ProductDemoApp.Data
{
    public static class AppDbContext
    {

        public static List<Product> Products { get; set; }

        static AppDbContext()
        {
            Products = new List<Product>()
            {
            new Product() { Id = 1, Title = "Gömlek", Price = 320.20m },
           new Product() { Id = 2, Title = "Pantolon", Price = 219.99m },
           new Product() { Id = 3, Title = "Kaban", Price = 960.68m },
           new Product() { Id = 5, Title = "Çorap", Price = 33.20m },
           new Product() { Id = 4, Title = "Pijama Takımı", Price = 330.20m }

            };
        }
        
        
     
    }
}
