using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Service;
using BiddingApp.BiddingEngine.DomainData;
using Moq;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{
    public class CategoriesUpdaterTests
    {
        public ITablesProvider tables;

        public CategoriesUpdaterTests()
        {
            CategoryTable categoryTable = new CategoryTable();
            Mock<ITablesProvider> mock = new Mock<ITablesProvider>();
            mock.Setup(x => x.GetCategoryTable()).Returns(categoryTable);

            tables = mock.Object; 
        }

        [Fact]
        public void UpdateElectronics_ShouldChangeTheListSize()
        { 
            ICategoryTable categoryTable = tables.GetCategoryTable();
            int actual_size = categoryTable.FetchAllCategories().Count;

            CategoriesUpdater.TablesProvider = tables;
            CategoriesUpdater.UpdateElectronics();

            int new_size = categoryTable.FetchAllCategories().Count;

            Assert.NotEqual(actual_size, new_size); 
        }

        [Fact]
        public void UpdateHome_ShouldChangeTheListSize()
        {
            ICategoryTable categoryTable = tables.GetCategoryTable();
            int actual_size = categoryTable.FetchAllCategories().Count;

            CategoriesUpdater.TablesProvider = tables;
            CategoriesUpdater.UpdateHome();

            int new_size = categoryTable.FetchAllCategories().Count;

            Assert.NotEqual(actual_size, new_size);
        } 

        [Fact]
        public void InsertCategoryList_ShouldAddNewListCountItems()
        {
            List<Category> toBeAdded = new List<Category>() {
                new Category() { Name = "ioi" },
                new Category() { Name = "iooi" },
                new Category() { Name = "iiiooi" }
            };
            int expected_difference = toBeAdded.Count;

            CategoriesUpdater.TablesProvider = tables;

            int actual_size = tables.GetCategoryTable().FetchAllCategories().Count;
            CategoriesUpdater.InsertCategoryList(toBeAdded);
            int resulted_size = tables.GetCategoryTable().FetchAllCategories().Count;

            int actual_difference = resulted_size - actual_size;

            Assert.Equal(expected_difference, actual_difference); 
        }

        [Fact]
        public void GetAllAvailableCategories_ShouldReturnALL()
        {
            CategoriesUpdater.UpdateCategories(tables); 

            Assert.NotEmpty(tables.GetCategoryTable().FetchAllCategories());
        } 
    }
}
