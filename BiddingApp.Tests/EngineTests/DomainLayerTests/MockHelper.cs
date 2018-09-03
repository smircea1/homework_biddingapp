using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{
    public class MockHelper
    {
        public static ITablesProvider GetTableProvider()
        {
            return new TableProviderTest();
        }

        private class TableProviderTest : ITablesProvider
        {
            class CategoryTableImpl : ICategoryTable
            {
                public List<Category> list;

                public CategoryTableImpl()
                {
                    list = new List<Category>();
                    list.Add(new Category() { Name = "blah" });
                    list.Add(new Category() { Name = "blah" });
                }
                public List<Category> FetchAllCategories()
                {
                    return list;
                }

                public Category FetchCategoryByName(string name)
                {
                    foreach (Category category in list)
                    {
                        if (category.Name.Equals(name))
                        {
                            return category;
                        }
                    }

                    return null;
                }

                public List<Category> FetchSubCategories(Category category)
                {
                    throw new NotImplementedException();
                }

                public void InsertCategory(Category category)
                {
                    list.Add(category);
                }
            };

            public IAuctionTable GetAuctionTable()
            {
                throw new NotImplementedException();
            }

            public IBidTable GetBidTable()
            {
                throw new NotImplementedException();
            }

            public ICategoryTable GetCategoryTable()
            {
                return new CategoryTableImpl();
            }

            public ICurrencyTable GetCurrencyTable()
            {
                throw new NotImplementedException();
            }

            public IPersonBidderTable GetPersonBidderTable()
            {
                throw new NotImplementedException();
            }

            public IPersonMarkTable GetPersonMarkTable()
            {
                throw new NotImplementedException();
            }

            public IPersonOfferorTable GetPersonOfferorTable()
            {
                throw new NotImplementedException();
            }

            public IPersonTable GetPersonTable()
            {
                throw new NotImplementedException();
            }

            public IProductTable GetProductTable()
            {
                throw new NotImplementedException();
            }
        };
    }
}
