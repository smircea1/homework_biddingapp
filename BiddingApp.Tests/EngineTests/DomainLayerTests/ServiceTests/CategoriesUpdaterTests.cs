using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Service;
using BiddingApp.BiddingEngine.DomainData;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{
    public class CategoriesUpdaterTests
    {
        public static ITablesProvider tables = MockHelper.GetTableProvider();

        [Fact]
        public void UpdateElectronics_ShouldChangeTheListSize()
        {
            ITablesProvider tables = MockHelper.GetTableProvider();
            ICategoryTable categoryTable = tables.GetCategoryTable();
            int actual_size = categoryTable.FetchAllCategories().Count; 

            if(tables == null)
            {
                throw new Exception("");
            }

            CategoriesUpdater.UpdateCategories(tables);

            int new_size = categoryTable.FetchAllCategories().Count;

            Assert.NotEqual(actual_size, new_size); 
        }
    }
}
