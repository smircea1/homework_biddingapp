//-----------------------------------------------------------------------
// <copyright file="Auction.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.Tests.DomainLayerTests.ModelTets
{
    using BiddingApp.BiddingEngine.DomainLayer;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using System;
    using Xunit; 

    public class AuctionTests
    {
        readonly Currency usd_currency = CurrencyConverter.CurrencyRates.GetCurrencyByName("USD");

        private Product productA;
        private Person personA;
        private Auction auctionA;

        private DateTime startDate;
        private DateTime endDate;

        private Person personB;

        public AuctionTests()
        {
            Product.Builder product_builder = new Product.Builder();
            product_builder.SetName("AProduct");
            product_builder.AddCategory(new Category("Food"));

            this.productA = product_builder.Build();

            Person.Builder person_builder = new Person.Builder();
            person_builder.SetId(123);
            person_builder.SetName("PersonA");

            this.personA = person_builder.Build();

            person_builder = new Person.Builder();
            person_builder.SetId(123);
            person_builder.SetName("PersonB");

            this.personB = person_builder.Build();

            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now.AddMinutes(30);

            Money starting_money = new Money(this.usd_currency, 20);

            Auction.Builder auction_builder = new Auction.Builder();
            auction_builder.SetOwner(this.personA.Id);
            auction_builder.SetStartDate(this.startDate);
            auction_builder.SetEndDate(this.endDate);
            auction_builder.SetProduct(this.productA);
            auction_builder.SetStartingMoney(starting_money);

            this.auctionA = auction_builder.Build(); 
        }

        [Fact]
        void GetBidsHistory_ShouldReturnNonNullList()
        {
            Assert.NotNull(auctionA.GetBidsHistory());
        }

        [Fact]
        void GetCurrency_ShouldReturnNonNullCurrency()
        {
            Assert.NotNull(auctionA.GetCurrency());
        }

        [Fact]
        void IsBidEligible_ShouldReturnTrueIfBidIsOK()
        { 
            Money bad_money = new Money(this.usd_currency, 31); 
            Money bad_money2 = new Money(this.usd_currency, 2); 
            Money good_money = new Money(this.usd_currency, 29);

            Bid bad_bid = new Bid(this.personA.Id, bad_money);
            Bid bad_bid2 = new Bid(this.personB.Id, bad_money2);
            Bid bad_bid3 = new Bid(this.personA.Id, good_money);

            Bid good_bid = new Bid(this.personB.Id, good_money);

            Assert.False(this.auctionA.IsBidEligible(bad_bid)); // will fail due to price + 50% * price
            Assert.False(this.auctionA.IsBidEligible(bad_bid2)); // will fail due to low price
            Assert.False(this.auctionA.IsBidEligible(bad_bid3)); // will fail cuz he bids own bid

            Assert.True(this.auctionA.IsBidEligible(good_bid));
        }

        [Fact]
        void AuctionBuilder_ShouldBuildAnAuction()
        {
            Auction.Builder builder = new Auction.Builder();

            Money bad = new Money(this.usd_currency, -1);
            Money good = new Money(this.usd_currency, 1);

            //// Empty build attempt
            Assert.ThrowsAny<Exception>(builder.Build);
             
            //// Incomplete build attempt
            builder.SetOwner(this.personA.Id);
            Assert.ThrowsAny<Exception>(builder.Build);

            //// Incomplete build attempt
            builder.SetProduct(this.productA);
            Assert.ThrowsAny<Exception>(builder.Build);

            //// Incomplete build attempt
            builder.SetProduct(this.productA);
            Assert.ThrowsAny<Exception>(builder.Build);

            //// badDate
            builder.SetStartDate(this.endDate);
            builder.SetEndDate(this.startDate);
            Assert.ThrowsAny<Exception>(builder.Build);
             
            //// Incomplete build attempt 
            builder.SetStartDate(this.startDate);
            builder.SetEndDate(this.endDate);
            Assert.ThrowsAny<Exception>(builder.Build);

            //// bad money attempt 
            builder.SetStartingMoney(bad);
            Assert.ThrowsAny<Exception>(builder.Build);

            builder.SetStartingMoney(good);
            Assert.NotNull(builder.Build());
        }
    }
}
