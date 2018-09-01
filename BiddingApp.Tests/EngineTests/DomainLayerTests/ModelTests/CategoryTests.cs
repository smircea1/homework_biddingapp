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
            category.Id = 1;
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
            Category category = new Category();
            category.Id = id;
            category.Name = name;

            Assert.ThrowsAny<Exception>(() => category.ValidateObject());
        }
    }
}
