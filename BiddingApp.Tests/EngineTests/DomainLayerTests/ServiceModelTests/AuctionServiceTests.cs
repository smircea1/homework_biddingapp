using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests
{
    public class AuctionServiceTests
    {
        [Fact]
        public void CreateAuctionService_ShouldInstantiateAuction()
        {
            var auction = InstanceHelper.GetAuctionService(null);
            Assert.NotNull(auction);
        }

        [Fact]
        public void EndAuction_ShouldEndAuction()
        {
            AuctionService auction = InstanceHelper.GetAuctionService(null);
            auction.EndAuction(auction.Auction.PersonOfferor);

            Assert.True(auction.HadEnded);
            Assert.False(auction.IsActive);
        }

        //[Fact]
        //public void UpdateStatus_ShouldUpdateStatus()
        //{
        //    AuctionService auction = InstanceHelper.GetAuctionService();
        //    auction.UpdateStatus();

        //    Assert.True(auction.HadEnded);
        //}
    }
}
