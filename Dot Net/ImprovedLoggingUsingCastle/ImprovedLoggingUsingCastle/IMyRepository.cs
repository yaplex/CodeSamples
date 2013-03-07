// Created at: 2013-03-06 4:02 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-06 4:36 PM

namespace ImprovedLoggingUsingCastle
{
    using System.Collections.Generic;

    public interface IMyRepository
    {
        ICollection<Product> GetAllProducts();
        Product GetById(int productId);
    }
}