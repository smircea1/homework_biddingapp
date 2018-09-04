using BiddingApp.BiddingEngine.DomainData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainDataTests
{
    public class DomainDataStorageTests
    {

        public DomainDataStorageTests()
        {

        }

        [Fact]
        public void DomainDataStorage_ShouldInstantiate()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds);
        }

        [Fact]
        public void GetAuctionTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetAuctionTable());
        }

        [Fact]
        public void GetBidTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetBidTable());
        }

        [Fact]
        public void GetCategoryTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetCategoryTable());
        }

        [Fact]
        public void GetCurrencyTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetCurrencyTable());
        }

        [Fact]
        public void GetPersonBidderTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetPersonBidderTable());
        }

        [Fact]
        public void GetPersonMarkTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetPersonMarkTable());
        }

        [Fact]
        public void GetPersonOfferorTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetPersonOfferorTable());
        }

        [Fact]
        public void GetPersonTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetPersonTable());
        }

        [Fact]
        public void GetProductTable_ShouldNotBeNull()
        {
            DomainDataStorage ds = DomainDataStorage.GetInstance();

            Assert.NotNull(ds.GetProductTable());
        }

    }
}
