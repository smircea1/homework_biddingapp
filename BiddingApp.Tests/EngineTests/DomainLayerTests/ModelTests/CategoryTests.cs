using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategoryOfferor_ShouldInstantiateCategory()
        {
            Category category = new Category();
            category.IdCategory = 1;
            category.Name = "Auto";

            category.ValidateObject();
            Assert.NotNull(category);
        }

        [Theory]
        [InlineData(-1, "Auto")]
        [InlineData(-1, "")]
        [InlineData(1, " ")]
        [InlineData(1, "")]
        [InlineData(1, null)]
        public void CreateCategoryOfferor_ShouldThrow(int id, string name)
        {
            Category category = new Category
            {
                IdCategory = id,
                Name = name
            };

            Assert.ThrowsAny<Exception>(() => category.ValidateObject());
        }

        [Fact]
        public void CreateCategoryOfferor_ShouldInstantiateCategory02()
        {
            Category category = new Category();
            category.IdCategory = 312;
            category.Name = "IT";

            category.ValidateObject();
            Assert.NotNull(category);
        }

        [Fact]
        public void CreateCategoryOfferor_ShouldInstantiateCategory03()
        {
            Category category = new Category();
            category.IdCategory = 10;
            category.Name = "Electronics";

            category.ValidateObject();
            Assert.NotNull(category);
        }

        [Fact]
        public void CreateCategoryOfferor_ShouldInstantiateCategory04()
        {
            Category category = new Category();
            category.IdCategory = 13113;
            category.Name = "Electronics Longer Name Than Usual";

            category.ValidateObject();
            Assert.NotNull(category);
        }
    }
}
