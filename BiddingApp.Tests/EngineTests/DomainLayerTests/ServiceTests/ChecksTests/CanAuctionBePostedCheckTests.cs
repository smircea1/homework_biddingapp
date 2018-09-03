using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Service.Checks;
using BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests;
using BiddingApp.BiddingEngine.DomainLayer.Model;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.ChecksTests
{
    public class CanAuctionBePostedCheckTests
    {
        [Fact]
        public void DoCheck_ShouldBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            var auction = InstanceHelper.GetAuction();
            var offerorAuction = new List<Auction>();
            var allProducts = new List<Product>();
            var result = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuction, allProducts);

            Assert.True(result);
        }

        [Fact]
        public void DoCheck_ShouldNotBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            offeror.LastBannedDate = DateTime.Now;
            var auction = InstanceHelper.GetAuction();
            var offerorAuction = new List<Auction>();
            var allProducts = new List<Product>();
            var result = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuction, allProducts);

            Assert.False(result);
        }
    }
}
