// Created at: 2013-03-06 4:35 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-06 4:38 PM

namespace ImprovedLoggingUsingCastle
{
    using System.Collections.Generic;
    using System.Linq;

    public class MyRepository : IMyRepository
    {
        public ICollection<Product> GetAllProducts()
        {
            var products = new List<Product>();
            products.Add(new Product {Id = 1, Name = "iPhone 4", IsAvailable = true});
            products.Add(new Product {Id = 10, Name = "iPhone 5", IsAvailable = true});
            products.Add(new Product {Id = 5, Name = "iPhone 6", IsAvailable = false});
            products.Add(new Product {Id = 8, Name = "Nexus 4", IsAvailable = true});
            return products;
        }

        public Product GetById(int productId)
        {
            return GetAllProducts().FirstOrDefault(x => x.Id == productId);
        }
    }
}