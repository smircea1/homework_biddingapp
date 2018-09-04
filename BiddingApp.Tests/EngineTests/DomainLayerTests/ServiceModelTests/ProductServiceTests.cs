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

        private static List<Product> GetGoodDescriptionProducts()
        {
            List<Product> producs = new List<Product>();
            var category = new Category
            {
                IdCategory = 1, 
                Name = "Electronics"
            };

            var product1 = new Product
            {
                IdProduct = 1,
                Name = "PC",
                Category = category,
                Description = "asd"
            };

            var product2 = new Product
            {
                IdProduct = 1,
                Name = "PC",
                Category = category,
                Description = "dsa"
            };

            producs.Add(product1);
            producs.Add(product2);

            return producs;
        }

        private static List<Product> GetBadDescriptionProducts()
        {
            List<Product> producs = new List<Product>();
            var category = new Category
            {
                IdCategory = 1, 
                Name = "Electronics"
            };

            var product1 = new Product
            {
                IdProduct = 1,
                Name = "PC",
                Category = category,
                Description = "asd"
            };

            var product2 = new Product
            {
                IdProduct = 1,
                Name = "PC",
                Category = category,
                Description = "i7, 1070 GTX, 16GB"
            };

            producs.Add(product1);
            producs.Add(product2);

            return producs;
        }

        [Fact]
        public void CreateService_ShouldInstantiateProductService()
        {
            var productService = GetProductService();
            Assert.NotNull(productService);
        }

        [Fact]
        public void HasSimilarDescriptionToAnyFrom_ShouldReturnFalse()
        {
            var productService = GetProductService();
            Assert.False(productService.HasSimilarDescriptionToAnyFrom(GetGoodDescriptionProducts()));
        }

        [Fact]
        public void HasSimilarDescriptionToAnyFrom_ShouldReturnTrue()
        {
            var productService = GetProductService();
            Assert.True(productService.HasSimilarDescriptionToAnyFrom(GetBadDescriptionProducts()));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("hello", "hello")]
        [InlineData("Hello", "hello")]
        [InlineData("hello-", "hello-")]
        [InlineData(".", "")]
        [InlineData(",", "")]
        [InlineData(":", "")]
        [InlineData("?", "")]
        [InlineData("asd!", "asd")]
        public void PrepareDescriptionForLevenstein__ShouldLowerAndRemoveChars(string text, string result)
        {
            string preparedText = ProductService.PrepareDescriptionForLevenstein(text);
            Assert.Equal(preparedText, result);
        }

        [Fact]
        public void RemoveCharsFromString_ShouldRemoveComma()
        {
            string source = ",";
            char[] charsToReplase = {','};
            string preparedText = ProductService.RemoveCharsFromString(source, charsToReplase);
            Assert.Equal("", preparedText);
        }

        [Fact]
        public void RemoveCharsFromString_ShouldRemoveMultipleChars()
        {
            string source = ".:?!,";
            char[] charsToReplase = { '.', ',', ':', '?', '!' };
            string preparedText = ProductService.RemoveCharsFromString(source, charsToReplase);
            Assert.Equal("", preparedText);
        }

        [Fact]
        public void RemoveCharsFromString_ShouldRemoveDots()
        {
            string source = "Ana.are.mere";
            char[] charsToReplase = { '.' };
            string preparedText = ProductService.RemoveCharsFromString(source, charsToReplase);
            Assert.Equal("Anaaremere", preparedText);
        }

        [Fact]
        public void RemoveCharsFromString_ShouldRemoveQuestionMark()
        {
            string source = "Ana?are?mere";
            char[] charsToReplase = { '?' };
            string preparedText = ProductService.RemoveCharsFromString(source, charsToReplase);
            Assert.Equal("Anaaremere", preparedText);
        }

        [Fact]
        public void RemoveCharsFromString_ShouldRemoveExclamationMark()
        {
            string source = "Ana!are!mere";
            char[] charsToReplase = { '!' };
            string preparedText = ProductService.RemoveCharsFromString(source, charsToReplase);
            Assert.Equal("Anaaremere", preparedText);
        }

        [Fact]
        public void RemoveCharsFromString_ShouldRemoveColumn()
        {
            string source = "Ana:are:mere";
            char[] charsToReplase = { ':' };
            string preparedText = ProductService.RemoveCharsFromString(source, charsToReplase);
            Assert.Equal("Anaaremere", preparedText);
        }
    }
}
