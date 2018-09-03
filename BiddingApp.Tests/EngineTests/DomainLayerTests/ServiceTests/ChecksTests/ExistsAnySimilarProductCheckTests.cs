using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Service.Checks;
using BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests;
using BiddingApp.BiddingEngine.DomainLayer.Model;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.ChecksTests
{
    public class ExistsAnySimilarProductCheckTests
    {
        [Fact]
        public void DoCheck_ShouldNotFindSimilar()
        {
            var product = InstanceHelper.GetProduct();
            var products = new List<Product>();
            var result = ExistsAnySimilarProductCheck.DoCheck(product, products);

            Assert.False(result);
        }

        [Fact]
        public void DoCheck_ShouldFindSimiar ()
        {
            var product = InstanceHelper.GetProduct();
            var products = new List<Product>();
            products.Add(InstanceHelper.GetProduct());

            var result = ExistsAnySimilarProductCheck.DoCheck(product, products);
            Assert.True(result);
        }
    }
}
