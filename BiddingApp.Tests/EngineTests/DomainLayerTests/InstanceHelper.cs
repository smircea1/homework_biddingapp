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
                LastBannedDate = DateTime.Now.AddDays(-3),
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

        public static PersonOfferorService GetPersonOfferorService(PersonOfferor personOfferor)
        {
            if (personOfferor != null) return new PersonOfferorService(personOfferor);
            return new PersonOfferorService(GetPersonOfferor());
        }

    }
}
