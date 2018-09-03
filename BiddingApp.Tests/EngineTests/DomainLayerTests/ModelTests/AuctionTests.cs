//-----------------------------------------------------------------------
// <copyright file="Auction.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    using BiddingApp.BiddingEngine.DomainLayer;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using System;
    using Xunit;

    public class AuctionTests
    {
        private static readonly int Id = 1;
        private static readonly PersonOfferor PersonOfferor = 
            new PersonOfferor { IdOfferor = 1 };
        private static readonly Product Product =
            new Product();
        private static readonly Currency Currency =
            new Currency();
        private static readonly DateTime StartDate =
            DateTime.Now.AddDays(-1);
        private static readonly DateTime EndDate =
            DateTime.Now.AddDays(1);
        private static readonly double StartValue = 1;

        private Auction GetAuctionInstance()
        {
            var auction = new Auction();
            auction.IdAuction = Id;
            auction.PersonOfferor = PersonOfferor;
            auction.Product = Product;
            auction.Currency = Currency;
            auction.StartDate = StartDate;
            auction.EndDate = EndDate;
            auction.StartValue = StartValue;

            return auction;
        }

        [Fact]
        public void CreateAuction_ShouldInstantiateAuction()
        {
            Auction auction = GetAuctionInstance();
            auction.ValidateObject();
            Assert.NotNull(auction);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void CreateAuction_ShouldThrowBadId(int id)
        {
            Auction auction = GetAuctionInstance();
            auction.IdAuction = id;

            Assert.ThrowsAny<Exception>(() => auction.ValidateObject());
        }

        [Fact]
        public void CreateAuction_ShouldThrowBadProduct()
        {
            Auction auction = GetAuctionInstance();
            auction.Product = null;

            Assert.ThrowsAny<Exception>(() => auction.ValidateObject());
        }

        [Fact]
        public void CreateAuction_ShouldThrowBadCurrency()
        {
            Auction auction = GetAuctionInstance();
            auction.Currency = null;

            Assert.ThrowsAny<Exception>(() => auction.ValidateObject());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void CreateAuction_ShouldThrowBadStartValue(int startValue)
        {
            Auction auction = GetAuctionInstance();
            auction.StartValue = startValue;

            Assert.ThrowsAny<Exception>(() => auction.ValidateObject());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-1000)]
        public void CreateAuction_ShouldThrowBadDate(int endDate)
        {
            Auction auction = GetAuctionInstance();
            auction.StartDate = DateTime.Now.AddDays(1);
            auction.EndDate = DateTime.Now.AddDays(endDate);

            Assert.ThrowsAny<Exception>(() => auction.ValidateObject());
        }
    }
}
