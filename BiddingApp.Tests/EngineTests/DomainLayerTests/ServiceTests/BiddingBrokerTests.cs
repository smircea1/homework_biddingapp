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

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{ 
    public class BiddingBrokerTests
    {
        ITablesProvider tables;

        public BiddingBrokerTests()
        {
            
        }

        private void ResetMockedDB()
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

            tables = mock.Object;
        }

        [Fact]
        public void BiddingBroker_ShouldReturnInstance()
        {
            ResetMockedDB();
            Assert.NotNull(new BiddingBroker(tables));
        }

        [Fact]
        public void RegisterPerson_ShouldInsertThePerson()
        {

        }

        [Fact]
        public void RegisterPerson_ShouldNotInsertThePerson()
        {

        }

        [Fact]
        public void RegisterAuction_ShouldRegisterOrReturnAlreadyRegistered()
        {

        }

        [Fact]
        public void RegisterAuction_ShouldThrowExceptionDueOfferor()
        {

        }

        [Fact]
        public void RegisterAuction_ShouldThrowExceptionDueProduct()
        {

        }

        [Fact]
        public void RegisterAuction_ShouldThrowExceptionDueLimits()
        {

        }

        [Fact]
        public void RegisterBid_ShouldRegisterBid()
        {

        }

        [Fact]
        public void RegisterBid_ShouldThrowExceptionDueBidder()
        {

        }

        [Fact]
        public void RegisterBid_ShouldThrowExceptionDueLowBid()
        {

        }

        [Fact]
        public void RegisterBid_ShouldThrowExceptionDueCurrency()
        {

        }

        [Fact] void EndAuction_ShouldEndAuction()
        {

        }

        [Fact]
        void EndAuction_ShouldThrowException()
        {

        }

        [Fact]
        public void PostMark_ShouldPostTheMark()
        {

        }

        [Fact]
        public void PostMark_ShouldThrowDueUnregisteredPerson()
        {

        }

        [Theory]
        [InlineData("07111111")]
        [InlineData("08111111")]
        public void GetPersonByPhone_ShouldReturnPerson(string phone)
        {

        }

        [Theory]
        [InlineData("012022304")]
        [InlineData("1123445")]
        public void GetPersonByPhone_ShouldReturnNullDueNotFound(string phone)
        {

        }

        [Fact]
        public void GetAvailableCategories_ShouldReturnNonEmptyList()
        {

        }

        [Fact]
        public void GetCategoryByName_ShouldReturnCategory()
        {

        }

        [Theory]
        [InlineData("dummycategory")]
        [InlineData("inexisting")]
        public void GetCategoryByName_ShouldReturnNull(string name)
        {

        }

        [Theory]
        [InlineData("dummycurrency")]
        [InlineData("leva")]
        public void GetCurrencyByName_ShouldReturnNull(string name)
        {

        }

        [Fact]
        public void GetCurrencyConverter_ShouldReturnCurrencyConverter()
        {

        }

    }
}
