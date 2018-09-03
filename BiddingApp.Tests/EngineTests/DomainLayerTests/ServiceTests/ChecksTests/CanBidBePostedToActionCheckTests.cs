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
    public class CanBidBePostedToActionCheckTests
    {
        [Fact]
        public void DoCheck_ShouldPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            var highestiBid = InstanceHelper.GetBid();
            highestiBid.PersonBidder.IdBidder = 2;
            highestiBid.Value = 1.49;

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.True(result);
        }

        [Fact]
        public void DoCheckHighestBid_ShouldNotPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            var highestiBid = new Bid();

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }

        [Fact]
        public void DoCheckPrice_ShouldNotPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            var highestiBid = InstanceHelper.GetBid();
            highestiBid.PersonBidder.IdBidder = 2;

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }

        [Fact]
        public void DoCheckPriceTooHigh_ShouldNotPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            var highestiBid = InstanceHelper.GetBid();
            highestiBid.PersonBidder.IdBidder = 2;
            highestiBid.Value = 1;

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }

        [Fact]
        public void DoCheckNullHighestBid_ShouldNotPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            Bid highestiBid = null;

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }

        [Fact]
        public void DoCheckNullPersonBidderAndWrongBid_ShouldNotPassCheck()
        {
            PersonBidder personBidder = null;

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            var highestiBid = InstanceHelper.GetBid();

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }

        [Fact]
        public void DoCheckCurrency_ShouldNotPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            Bid highestiBid = InstanceHelper.GetBid();
            bid.Currency = new Currency
            {
                IdCurrency = 2,
                Name = "EUR"
            };

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }

        [Fact]
        public void DoCheckAuction_ShouldNotPassCheck()
        {
            var personBidder = InstanceHelper.GetPersonBidder();

            var bid = InstanceHelper.GetBid();
            var auction = InstanceHelper.GetAuction();
            auction.EndDate = DateTime.Now;
            Bid highestiBid = InstanceHelper.GetBid();

            var result = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highestiBid);
            Assert.False(result);
        }
    }
}
