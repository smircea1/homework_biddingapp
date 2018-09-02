using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class BidTests
    {

        private static readonly int IdBid = 1;
        private static readonly PersonBidder PersonBidder = new PersonBidder();
        private static readonly Auction Auction = new Auction();
        private static readonly Currency Currency = new Currency();
        private static readonly double Value = 2;
        private static readonly DateTime Date = DateTime.Now;

        private Bid GetBidInstance()
        {
            Bid bid = new Bid
            {
                IdBid = IdBid,
                PersonBidder = PersonBidder,
                Auction = Auction,
                Currency = Currency,
                Value = Value,
                Date = Date
            };

            return bid;
        }

        [Fact]
        public void CreateBid_ShouldInstantiateAuction()
        {
            Bid bid = GetBidInstance();
            bid.ValidateObject();
            Assert.NotNull(bid);
        }

        [Fact]
        public void CreateBid_ShouldTwrowBadBidder()
        {
            Bid bid = GetBidInstance();
            bid.PersonBidder = null;

            Assert.ThrowsAny<Exception>(() => bid.ValidateObject());
        }

        [Fact]
        public void CreateBid_ShouldTwrowBadAuction()
        {
            Bid bid = GetBidInstance();
            bid.Auction = null;

            Assert.ThrowsAny<Exception>(() => bid.ValidateObject());
        }

        [Fact]
        public void CreateBid_ShouldTwrowBadCurrency()
        {
            Bid bid = GetBidInstance();
            bid.Currency = null;

            Assert.ThrowsAny<Exception>(() => bid.ValidateObject());
        }
    }
}
