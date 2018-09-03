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
    public class CanOfferorEndAuctionCheckTests
    {
        [Fact]
        public void DoCheck_ShouldBeValid()
        {
            var offeror = InstanceHelper.GetPersonOfferor();
            var auctionServcie = InstanceHelper.GetAuctionService(null);

            // If throws error, this test will fail
            CanOfferorEndAuctionCheck.DoCheck(offeror, auctionServcie);
            Assert.True(true);
        }

        [Fact]
        public void DoCheckOfferor_ShouldThrow()
        {
            PersonOfferor offeror = null;
            var auctionServcie = InstanceHelper.GetAuctionService(null);

            Assert.ThrowsAny<Exception>(() => CanOfferorEndAuctionCheck.DoCheck(offeror, auctionServcie));
        }

        [Fact]
        public void DoCheckIdOfferor_ShouldThrow()
        {
            PersonOfferor offeror = InstanceHelper.GetPersonOfferor();
            offeror.IdOfferor = 2;
            var auctionServcie = InstanceHelper.GetAuctionService(null);

            Assert.ThrowsAny<Exception>(() => CanOfferorEndAuctionCheck.DoCheck(offeror, auctionServcie));
        }

        [Fact]
        public void DoCheckEndedAuction_ShouldThrow()
        {
            PersonOfferor offeror = InstanceHelper.GetPersonOfferor();
            var auctionServcie = InstanceHelper.GetAuctionService(null);
            var updatedAuction = auctionServcie.EndAuction(offeror);

            Assert.ThrowsAny<Exception>(() => CanOfferorEndAuctionCheck.DoCheck(offeror, updatedAuction));
        }
    }
}
