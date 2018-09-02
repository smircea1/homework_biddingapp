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
        public void CreateAuction_ShouldInstantiateAuction()
        {
            var auction = InstanceHelper.GetAuction();
            Assert.NotNull(auction);
        }

        [Fact]
        public void EndAuction_ShouldEndAuction()
        {
            AuctionService auction = InstanceHelper.GetAuctionService();
            auction.EndAuction(InstanceHelper.GetPersonOfferor());

            Assert.True(auction.HadEnded);
        }
    }
}
