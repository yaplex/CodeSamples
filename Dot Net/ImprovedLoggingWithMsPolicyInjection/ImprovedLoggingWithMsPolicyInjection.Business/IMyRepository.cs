// Created at: 2013-03-04 1:49 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-04 1:49 PM
namespace ImprovedLoggingWithMsPolicyInjection.Business
{
    using System.Collections.Generic;
    using Models;

    public interface IMyRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
    }
}