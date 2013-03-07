// Created at: 2013-03-06 12:42 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-07 12:13 PM

namespace ImprovedLoggingUsingCastle
{
    using System;
    using System.IO;
    using System.Linq;
    using StructureMap;
    using log4net;
    using log4net.Config;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ObjectFactory.Initialize(x => x.For<IMyRepository>().Use<MyRepository>());
            ObjectFactory.Configure(x => x.RegisterInterceptor(new StructureMapInterceptor()));

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            var config = new FileInfo(filePath);
            XmlConfigurator.ConfigureAndWatch(config);

            var log = LogManager.GetLogger("Programm");
            log.Debug("Initializtion done!");

            var repo = ObjectFactory.GetInstance<IMyRepository>();
            var allProducts = repo.GetAllProducts();
            var singleProduct = repo.GetById(allProducts.First().Id);
            log.Debug(string.Format("Product found: {0}", singleProduct.ToString()));

        }
    }
}