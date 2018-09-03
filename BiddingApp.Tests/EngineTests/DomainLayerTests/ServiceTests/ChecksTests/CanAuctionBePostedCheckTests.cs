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
        public void DoCheckBanned_ShouldNotBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            offeror.LastBannedDate = DateTime.Now;
            var auction = InstanceHelper.GetAuction();
            var offerorAuction = new List<Auction>();
            var allProducts = new List<Product>();
            var result = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuction, allProducts);

            Assert.False(result);
        }

        [Fact]
        public void DoCheckMaxAuctions_ShouldNotBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            var auction = InstanceHelper.GetAuction();
            var offerorAuction = new List<Auction>();
            for (int i = 0; i < 3; i++)
            {
                offerorAuction.Add(InstanceHelper.GetAuction());
            }
            var allProducts = new List<Product>();
            var result = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuction, allProducts);

            Assert.False(result);
        }

        [Fact]
        public void DoCheckSimiliarAuctions_ShouldNotBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            var auction = InstanceHelper.GetAuction();
            var offerorAuction = new List<Auction>();
            var allProducts = new List<Product>();
            allProducts.Add(InstanceHelper.GetProduct());
            var result = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuction, allProducts);

            Assert.False(result);
        }

        [Fact]
        public void DoCheckMaxCategory_ShouldNotBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            var auction = InstanceHelper.GetAuction();
            var offerorAuction = new List<Auction>();
            var allProducts = new List<Product>();
            allProducts.Add(InstanceHelper.GetProduct());
            allProducts.Add(InstanceHelper.GetProduct());
            var result = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuction, allProducts);

            Assert.False(result);
        }
    }
}
