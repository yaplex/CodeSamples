using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedLoggingWithMsPolicyInjection
{
    using Business;
    using DataAccess;
    using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            IMyRepository repo = new MyRepository();
            IMyRepository proxyRepo = PolicyInjection.Wrap<IMyRepository>(repo);

            var allProducts = proxyRepo.GetAllProducts();
            foreach (var product in allProducts)
            {
                Console.WriteLine("Product: {0}", product.Name);
            }

            Console.WriteLine();
            var nexus4 = proxyRepo.GetProduct(3);
            Console.WriteLine("Product with Id=3: is {0}", nexus4.Name);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
