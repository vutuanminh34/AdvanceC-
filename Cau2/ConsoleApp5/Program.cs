using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp5
{
    class Program
    {
        public class Category
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
            public int Count { get; set; }
            public decimal TotalPrice { get; set; }
            public List<Product> Products { get; set; }
        }

        public class Product
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
            public string Country { get; set; }
            public string Price { get; set; }
        }

        
        static void Main(string[] args)
        {
            var list = new List<Product>()
    {
        new Product()
            {Type = "Classic", Color = "red", Country = "USA", Name = "BMW", Price = "1"},
        new Product()
            {Type = "Modern", Color = "red", Country = "USA", Name = "Lamborghini", Price = "1.5"},
        new Product()
            {Type = "Classic", Color = "red", Country = "VN", Name = "Mercedes", Price = "1"},
        new Product()
            {Type = "Classic", Color = "blue", Country = "USA", Name = "Mercedes", Price = "1.2"},
        new Product()
            {Type = "Classic", Color = "red", Country = "USA", Name = "Mercedes", Price = "2"},
        new Product()
            {Type = "Modern", Color = "blue", Country = "VN", Name = "Ferrari", Price = "2.5"},
        new Product()
            {Type = "Modern", Color = "blue", Country = "USA", Name = "Ferrari", Price = "3.2"},
        new Product()
            {Type = "Classic", Color = "red", Country = "VN", Name = "Mercedes", Price = "1.3"},
        new Product()
            {Type = "Modern", Color = "red", Country = "VN", Name = "Lamborghini", Price = "3"},
    };

            var newlist = list
                .GroupBy(x => new { x.Type, x.Color, x.Name })
                .Select(y => new Category()
                {
                    
                    Type = y.Key.Type,
                    Color = y.Key.Color,
                    Name = y.Key.Name,
                    TotalPrice = y.Sum(x=>Convert.ToDecimal(x.Price)),
                    Products = y.ToList()
                })
                .OrderByDescending(y => y.TotalPrice);

            
            foreach (var item in newlist)
            {
                Console.WriteLine("Type: {0}     Color: {1}     Name: {2}", item.Type, item.Color, item.Name);
                foreach (var newitem in item.Products)
                {
                    Console.WriteLine("     Country: {0}    Price: {1}", newitem.Country, newitem.Price);
                }
                    Console.WriteLine("     TotalPrice: " + item.TotalPrice);
            }
        }
    }
}
