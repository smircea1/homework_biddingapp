using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests
{
    public class InstanceHelper
    {
        public static Currency GetCurrency()
        {
            return new Currency
            {
                IdCurrency = 1,
                Name = "RON"
            };
        }

        public static Person GetPerson ()
        {
            return new Person
            {
                IdPerson = 1,
                Name = "Gigi",
                Phone = "0728829291"
            };
        }


        public static PersonOfferor GetPersonOfferor()
        {
            return new PersonOfferor
            {
                IdOfferor = 1,
                LastBannedDate = DateTime.Now.AddDays(-365),
                Person = GetPerson()
            };
        }
        
        public static Category GetCategory()
        {
            return new Category
            {
                IdCategory = 1,
                IdParent = 2,
                Name = "Electronics"
            };
        }

        public static Product GetProduct()
        {
            return new Product
            {
                IdProduct = 1,
                Name = "PC",
                Category = GetCategory(),
                Description = "i7, 1070 GTX, 16GB RAM"
            };
        }

        public static Auction GetAuction()
        {
            return new Auction
            {
                IdAuction = 1,
                StartValue = 1,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(1),
                Currency = GetCurrency(),
                PersonOfferor = GetPersonOfferor(),
                Product = GetProduct()
            };
        }

        public static AuctionService GetAuctionService(Auction auction)
        {
            if (auction != null)
                return new AuctionService(auction);
            return new AuctionService(GetAuction());
        }

        public static PersonBidder GetPersonBidder()
        {
            return new PersonBidder
            {
                IdBidder = 1,
                Person = GetPerson()
            };
        }

        public static Bid GetBid()
        {
            return new Bid
            {
                IdBid = 1,
                Date = DateTime.Now,
                Auction = GetAuction(),
                Currency = GetCurrency(),
                PersonBidder = GetPersonBidder(),
                Value = 2
            };
        }

        public static PersonOfferorService GetPersonOfferorService(PersonOfferor personOfferor)
        {
            if (personOfferor != null) return new PersonOfferorService(personOfferor);
            return new PersonOfferorService(GetPersonOfferor());
        }

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
                    foreach(Category category in list)
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
