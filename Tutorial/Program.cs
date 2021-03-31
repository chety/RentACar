using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Computer" },
                new Category { Id = 2, Name = "Phone" }
            };

            var products = new List<Product>
            {
                new Product { Id = 1, CategoryId = 1, Name = "Apple Macintosh", UnitPrice = 20000, UnitsInStock = 144},
                new Product { Id = 2, CategoryId = 1, Name = "Sony Viao", UnitPrice = 14523, UnitsInStock = 250},
                new Product { Id = 3, CategoryId = 1, Name = "Lenovo Thinkpad", UnitPrice = 15000, UnitsInStock = 10},
                new Product { Id = 4, CategoryId = 2, Name = "Samsung Galaxy Note", UnitPrice = 12000, UnitsInStock = 0},
                new Product { Id = 5, CategoryId = 2, Name = "Apple X", UnitPrice = 19500, UnitsInStock = 100}
            };

            var result = from c in categories
                         join p in products
                         on c.Id equals p.CategoryId
                         where p.UnitPrice > 12000 && p.UnitsInStock > 50
                         select new { CategoryName = c.Name, ProductName = p.Name };

            result.ToList().ForEach(item => WriteLine($"Product Name: {item.ProductName}, Category Name: {item.CategoryName}"));



            //foreach (var product in products)
            //{
            //    if (product.UnitPrice > 15000 && product.UnitsInStock > 50)
            //    {
            //        WriteLine(product.Name);
            //    }
            //}

        }
    }

    class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }

    }

    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
