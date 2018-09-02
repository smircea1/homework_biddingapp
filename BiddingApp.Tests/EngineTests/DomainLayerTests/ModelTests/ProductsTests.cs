using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class ProductsTests
    {
        [Fact]
        public void CreateProduct_ShouldInsantiateProduct()
        {
            var product = new Product();
            product.Description = "Description";
            product.IdProduct = 1;
            product.Name = "Product";
            product.Category = new Category{ IdCategory = 1, Name = "name" };

            product.ValidateObject();
            Assert.NotNull(product);
        }

        [Fact]
        public void CreateProduct_ShouldThrowBadDescription()
        {
            var product = new Product();
            product.Description = "";
            product.IdProduct = 1;
            product.Name = "Product";
            product.Category = new Category { IdCategory = 1, Name = "name" };

            Assert.ThrowsAny<Exception>(() => product.ValidateObject());
        }

        [Fact]
        public void CreateProduct_ShouldThrowBadId()
        {
            var product = new Product();
            product.Description = "Description";
            product.IdProduct = -1;
            product.Name = "Product";
            product.Category = new Category { IdCategory = 1, Name = "name" };

            Assert.ThrowsAny<Exception>(() => product.ValidateObject());
        }

        [Fact]
        public void CreateProduct_ShouldThrowBadName()
        {
            var product = new Product();
            product.Description = "Description";
            product.IdProduct = 1;
            product.Name = " ";
            product.Category = new Category { IdCategory = 1, Name = "name" };

            Assert.ThrowsAny<Exception>(() => product.ValidateObject());
        }

        [Fact]
        public void CreateProduct_ShouldThrowBadDescription02()
        {
            var product = new Product();
            product.Description = null;
            product.IdProduct = 1;
            product.Name = "Product";
            product.Category = new Category { IdCategory = 1, Name = "name" };

            Assert.ThrowsAny<Exception>(() => product.ValidateObject());
        }

        [Fact]
        public void CreateProduct_ShouldThrowBadName02()
        {
            var product = new Product();
            product.Description = "Description";
            product.IdProduct = 1;
            product.Name = null;
            product.Category = new Category { IdCategory = 1, Name = "name" };

            Assert.ThrowsAny<Exception>(() => product.ValidateObject());
        }

        [Fact]
        public void CreateProduct_ShouldThrowBadCategory()
        {
            var product = new Product();
            product.Description = "Description";
            product.IdProduct = 1;
            product.Name = "Name";
            product.Category = null;

            Assert.ThrowsAny<Exception>(() => product.ValidateObject());
        }
    }
}
