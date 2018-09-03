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

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{ 
    public class BiddingBrokerTests
    {
        ITablesProvider tables;

        public BiddingBrokerTests()
        {
            CategoryTable categoryTable = new CategoryTable();
            CurrencyTable currencyTable = new CurrencyTable();

            Mock<ITablesProvider> mock = new Mock<ITablesProvider>();
            mock.Setup(x => x.GetCategoryTable()).Returns(categoryTable);
            mock.Setup(x => x.GetCurrencyTable()).Returns(currencyTable);
        }

        [Fact]
        public void BiddingBroker_ShouldReturnInstance()
        {

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

        [Fact]
        public void GetPersonByPhone_ShouldReturnPerson()
        {

        }

        [Fact]
        public void GetPersonByPhone_ShouldReturnNullDueNotFound()
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
