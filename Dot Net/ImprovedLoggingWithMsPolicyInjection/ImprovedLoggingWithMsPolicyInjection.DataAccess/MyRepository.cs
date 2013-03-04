// Created at: 2013-03-04 1:48 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-04 1:54 PM

namespace ImprovedLoggingWithMsPolicyInjection.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Business;
    using Business.Models;
    using Microsoft.Practices.Unity.InterceptionExtension;

    [Tag("Logging")]
    public class MyRepository : IMyRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            // get it from database or from wcf service...
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("I am inside of the GetAllProductions method. Getting productions from database...");
            Console.ForegroundColor = oldColor;

            var products = new List<Product>();
            products.Add(new Product {CreatedAt = DateTime.Now, Id = 15, IsAvailable = true, Name = "iPhone 4"});
            products.Add(new Product
                             {
                                 CreatedAt = DateTime.Now.AddDays(-320),
                                 Id = 2,
                                 IsAvailable = true,
                                 Name = "iPhone 4s"
                             });
            products.Add(new Product {CreatedAt = DateTime.Now, Id = 6, IsAvailable = true, Name = "iPhone 5"});
            products.Add(new Product
                             {
                                 CreatedAt = DateTime.Now.AddMonths(-1),
                                 Id = 3,
                                 IsAvailable = true,
                                 Name = "Nexus 4"
                             });
            products.Add(new Product
                             {
                                 CreatedAt = DateTime.Now.AddDays(200),
                                 Id = 32,
                                 IsAvailable = false,
                                 Name = "iPhone 6"
                             });
            return products;
        }

        public Product GetProduct(int id)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("I am inside of GetProduct method. Getting product with id={0} from database", id);
            Console.ForegroundColor = oldColor;
            return GetAllProducts().First(x => x.Id == id);
        }
    }
}