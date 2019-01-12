using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Service;
using BiddingApp.BiddingEngine.DomainData;
using Moq;
using BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables;
using BiddingApp.BiddingEngine.DomainLayer;
using BiddingApp.BiddingEngine.DomainLayer.Model;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{
    public class BiddingBrokerTests
    {
        public BiddingBrokerTests()
        {

        }

        private ITablesProvider InitMockedDb()
        {
            CategoryTable categoryTable = new CategoryTable();
            CurrencyTable currencyTable = new CurrencyTable();

            PersonTable personTable = new PersonTable();

            BidTable bidTable = new BidTable();
            PersonBidderTable personBidderTable = new PersonBidderTable(bidTable);

            AuctionsTable auctionsTable = new AuctionsTable();
            ProductTable productTable = new ProductTable();

            PersonMarkTable personMarkTable = new PersonMarkTable();
            PersonOfferorTable personOfferorTable = new PersonOfferorTable();


            Mock<ITablesProvider> mock = new Mock<ITablesProvider>();
            mock.Setup(x => x.GetCategoryTable()).Returns(categoryTable);
            mock.Setup(x => x.GetCurrencyTable()).Returns(currencyTable);

            mock.Setup(x => x.GetPersonTable()).Returns(personTable);

            mock.Setup(x => x.GetBidTable()).Returns(bidTable);
            mock.Setup(x => x.GetPersonBidderTable()).Returns(personBidderTable);

            mock.Setup(x => x.GetAuctionTable()).Returns(auctionsTable);
            mock.Setup(x => x.GetProductTable()).Returns(productTable);

            mock.Setup(x => x.GetPersonMarkTable()).Returns(personMarkTable);
            mock.Setup(x => x.GetPersonOfferorTable()).Returns(personOfferorTable);

            return mock.Object;
        }

        public Product GetGoodProduct(BiddingBroker broker)
        {
            Product goodProduct = new Product() { Name = "Mouse", Description = "Logitech" };
            goodProduct.Category = broker.GetCategoryByName("PC Periferics");

            return goodProduct;
        }

        public Person GetGoodPerson(BiddingBroker broker)
        {
            Person goodPerson = new Person() { Name = "gigica", Phone = "07299544321" };
            goodPerson = broker.RegisterPerson(goodPerson);

            return goodPerson;
        }

        public Person GetGoodPerson2(BiddingBroker broker)
        {
            Person goodPerson = new Person() { Name = "ggz", Phone = "9933845523" };
            goodPerson = broker.RegisterPerson(goodPerson); 

            return goodPerson;
        }

        public Auction GetGoodAuction(BiddingBroker broker)
        {

            Product goodProduct = GetGoodProduct(broker);

            double startValue = 123.3;
            Currency currency = broker.GetCurrencyByName("ron");

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1);

            Auction goodAuction = new Auction()
            {
                StartDate = startDate,
                EndDate = endDate,
                StartValue = startValue
            };

            goodAuction.Product = goodProduct;
            goodAuction.Currency = currency;

            return goodAuction;
        }

        [Fact]
        public void BiddingBroker_ShouldReturnInstance()
        {
            InitMockedDb();
            Assert.NotNull(new BiddingBroker(InitMockedDb()));
        }

        [Fact]
        public void RegisterPerson_ShouldInsertThePerson()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Person goodPerson = GetGoodPerson(broker);

            Assert.NotEqual(0, goodPerson.IdPerson);
        }

        [Fact]
        public void RegisterPerson_ShouldThrowDueExisting()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Person bad = GetGoodPerson(broker);
            bad.IdPerson = 0;

            Assert.NotNull(broker.RegisterPerson(bad)); 
        }

        [Fact]
        public void RegisterPerson_ShouldThrowDueId()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person bad = new Person() {IdPerson = 1 ,Name = "gigica", Phone = "07299544321" };  
            Assert.ThrowsAny<Exception>(() => broker.RegisterPerson(bad)); 
        }

        [Fact]
        public void RegisterPerson_ShouldNotInsertThePerson()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Person badPerson2 = new Person() { Name = null, Phone = "07299544321" };

            Assert.ThrowsAny<Exception>(() => broker.RegisterPerson(badPerson2));
        }

        [Fact]
        public void RegisterAuction_ShouldRegisterOrReturnAlreadyRegistered()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);

            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);
        }

        [Fact]
        public void RegisterAuction_ShouldThrowExceptionDueOfferor()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person badPerson3 = new Person() { Name = "gigica", Phone = null };

            Auction goodAuction = GetGoodAuction(broker);

            Assert.ThrowsAny<Exception>(() => broker.RegisterAuction(badPerson3, goodAuction));
        }

        [Fact]
        public void RegisterAuction_ShouldThrowExceptionDueProduct()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Product badProduct = new Product() { Name = "bad" };

            goodAuction.Product = badProduct;

            Assert.ThrowsAny<Exception>(() => broker.RegisterAuction(goodPerson, goodAuction));
        }

        [Fact]
        public void RegisterBid_ShouldRegisterBid()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            Person bidder = GetGoodPerson2(broker);
            double value = goodAuction.StartValue + 1;

            Bid bid = new Bid()
            {
                Currency = goodAuction.Currency,
                Date = DateTime.Now,
                Value = value,
                Auction = goodAuction,
            };

            //SHOULD NOT THROW
            bool throwed = false;
            try
            {
                broker.RegisterBid(bidder, bid, goodAuction);
            } catch (Exception )
            {
                throwed = true;
            }

            Assert.False(throwed);
        }


        [Theory]
        [InlineData(999)]
        [InlineData(200)]
        [InlineData(5)]
        public void RegisterBid_ShouldThrowExceptionDueValue(double value)
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            Person bidder = GetGoodPerson2(broker);

            Bid bid = new Bid()
            {
                Currency = goodAuction.Currency,
                Date = DateTime.Now,
                Value = value,
                Auction = goodAuction,
            };

            Assert.ThrowsAny<Exception>(() => broker.RegisterBid(bidder, bid, goodAuction));
        }

        [Fact]
        public void RegisterBid_ShouldThrowExceptionDueBidder()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            Person bidder = new Person() { Name = "bad" };
            double value = goodAuction.StartValue + 1;

            Bid bid = new Bid()
            {
                Currency = goodAuction.Currency,
                Date = DateTime.Now,
                Value = value,
                Auction = goodAuction,
            };

            Assert.ThrowsAny<Exception>(() => broker.RegisterBid(bidder, bid, goodAuction));
        }

        [Fact]
        public void RegisterBid_ShouldThrowExceptionDueLowBid()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            Person bidder = GetGoodPerson2(broker);
            double bad_value = goodAuction.StartValue - 1;

            Bid bid = new Bid()
            {
                Currency = goodAuction.Currency,
                Date = DateTime.Now,
                Value = bad_value,
                Auction = goodAuction,
            };

            Assert.ThrowsAny<Exception>(() => broker.RegisterBid(bidder, bid, goodAuction));
        }

        [Fact]
        public void RegisterBid_ShouldThrowExceptionDueCurrency()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            Person bidder = GetGoodPerson2(broker);
            double bad_value = goodAuction.StartValue - 1;

            Bid bid = new Bid()
            {
                Currency = broker.GetCurrencyByName("eur"),
                Date = DateTime.Now,
                Value = bad_value,
                Auction = goodAuction,
            };

            Assert.ThrowsAny<Exception>(() => broker.RegisterBid(bidder, bid, goodAuction));
        }

        [Fact] void EndAuction_ShouldEndAuction()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);
            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            bool didThrow = false;
            try
            {
                broker.EndAuction(goodPerson, goodAuction);
            } catch (Exception)
            {
                didThrow = true;
            }

            Assert.False(didThrow);
        }

        [Fact]
        void EndAuction_ShouldThrowException()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Auction goodAuction = GetGoodAuction(broker);

            Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);
            Assert.NotNull(registeredAuction);
            Assert.NotEqual(0, registeredAuction.IdAuction);

            Person good2 = GetGoodPerson2(broker);

            Assert.ThrowsAny<Exception>(() => broker.EndAuction(good2, goodAuction));
        }

        [Fact]
        public void PostMark_ShouldPostTheMark()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Person good2 = GetGoodPerson2(broker);

            broker.PostMark(goodPerson, good2, 5);
        }

        [Fact]
        public void PostMark_ShouldThrowDueIdSender()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            goodPerson.IdPerson = 0;
            Person good2 = GetGoodPerson2(broker);

            Assert.ThrowsAny<Exception>(() => broker.PostMark(goodPerson, good2, 5));
        }

        [Fact]
        public void PostMark_ShouldThrowDueIdReceiver()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Person good2 = GetGoodPerson2(broker);
            good2.IdPerson = 0;

            Assert.ThrowsAny<Exception>(() => broker.PostMark(goodPerson, good2, 5)); 
        }

        [Fact]
        public void PostMark_ShouldPostTheMarkAndUpdate()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Person good2 = GetGoodPerson2(broker);

            broker.PostMark(goodPerson, good2, 5);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void PostMark_ShouldThrowDueMarkInvalid(int mark)
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Person goodPerson = GetGoodPerson(broker);
            Person good2 = GetGoodPerson2(broker);

            Assert.ThrowsAny<Exception>(() => broker.PostMark(goodPerson, good2, mark));
        }

        [Fact]
        public void PostMark_ShouldThrowDueUnregisteredPerson()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Person good = GetGoodPerson(broker);

            Person bad = new Person() { Name = "ups", Phone = "un phone" }; 

            Assert.ThrowsAny<Exception>(() => broker.PostMark(good, bad, 5));
        }

        [Theory]
        [InlineData("07111111")]
        [InlineData("08111111")]
        public void GetPersonByPhone_ShouldReturnPerson(string phone)
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Person goodPerson = new Person() { Name = "gigica", Phone = phone };

            broker.RegisterPerson(goodPerson); 

            Assert.NotNull(broker.GetPersonByPhone(phone));
        }

        [Theory]
        [InlineData("012022304")]
        [InlineData("1123445")]
        public void GetPersonByPhone_ShouldReturnNullDueNotFound(string phone)
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Assert.Null(broker.GetPersonByPhone(phone));
        }

        [Fact]
        public void GetAvailableCategories_ShouldReturnNonEmptyList()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Assert.NotNull(broker.GetAvailableCategories());
            Assert.NotEmpty(broker.GetAvailableCategories());
        }

        [Fact]
        public void GetCategoryByName_ShouldReturnCategory()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
             
            Assert.NotNull(broker.GetCategoryByName("Home"));
        }

        [Theory]
        [InlineData("dummycategory")]
        [InlineData("inexisting")]
        public void GetCategoryByName_ShouldThrow(string name)
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb()); 
            Assert.ThrowsAny<Exception>(() => broker.GetCategoryByName(name)); 
        }

        [Theory]
        [InlineData("dummycurrency")]
        [InlineData("leva")]
        public void GetCurrencyByName_ShouldNotThrow(string name)
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());
            Assert.ThrowsAny<Exception>(()=> broker.GetCurrencyByName(name)); 
        }

        [Fact]
        public void GetCurrencyConverter_ShouldReturnCurrencyConverter()
        {
            BiddingBroker broker = new BiddingBroker(InitMockedDb());

            Assert.NotNull(broker.GetCurrencyConverter());
        }

    }
}
