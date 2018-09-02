using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests
{
    public class ProductServiceTests
    {
        private static ProductService GetProductService()
        {
            var category = new Category
            {
                IdCategory = 1,
                IdParent = 2,
                Name = "Electronics"
            };

            var product = new Product
            {
                IdProduct = 1,
                Name = "PC",
                Category = category,
                Description = "i7, 1070 GTX, 16GB RAM"
            };

            return new ProductService(product);
        }
    }
}
