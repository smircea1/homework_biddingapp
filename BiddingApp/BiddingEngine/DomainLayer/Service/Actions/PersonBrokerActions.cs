//-----------------------------------------------------------------------
// <copyright file="PersonBrokerActions.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------

namespace BiddingApp.BiddingEngine.DomainLayer.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// This is the link between a person and a broker.
    /// </summary>
    public class PersonBrokerActions
    {
        /// <summary>
        /// Requests the auction.
        /// </summary>
        /// <param name="broker">The broker.</param>
        /// <param name="person">The person.</param>
        /// <param name="product">The product.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="startingMoney">The starting money.</param>
        /// <returns>False if it can't post the bid request</returns>
        public static bool RequestAuction(BiddingBroker broker, Person person, Product product, DateTime start, DateTime end, Money startingMoney)
        {
            if (person.IsBanned)
            {
                return false;
            }

            if (broker.DidPersonHitMaxListLimit(person))
            {
                return false;
            }

            foreach (Category category in product.Categories)
            {
                if (!broker.DidPersonHitMaxCategoryListLimit(person, category))
                {
                    return false;
                }
            }

            Auction.Builder auctionBuilder = new Auction.Builder();
            auctionBuilder.SetEndDate(end);
            auctionBuilder.SetStartDate(start);
            auctionBuilder.SetStartingMoney(startingMoney);
            auctionBuilder.SetProduct(product);
            auctionBuilder.SetOwner(person);

            Auction auctionCreated = auctionBuilder.Build();

            return broker.RegisterAuction(auctionCreated); 
        }

        /// <summary>
        /// Ends the auction.
        /// </summary>
        /// <param name="broker">The broker.</param>
        /// <param name="person">The person.</param>
        /// <param name="auction">The auction.</param>
        /// <returns>False if it cannot end the specified auction.</returns>
        public static bool EndAuction(BiddingBroker broker, Person person, Auction auction)
        { 
            Person owner = auction.ProductOwner;

            if (!owner.Id.Equals(person.Id))
            {
                return false;
            }
             
            if (auction.IsEnded)
            {
                return false;
            }

            return broker.EndAuction(auction); 
        }

        /// <summary>
        /// Bids the auction.
        /// </summary>
        /// <param name="broker">The broker.</param>
        /// <param name="person">The person.</param>
        /// <param name="auction">The auction.</param>
        /// <param name="money">The money.</param>
        /// <returns>false if the place bid had failed</returns>
        public static bool BidAuction(BiddingBroker broker, Person person, Auction auction, Money money)
        {  
            Currency auction_currency = auction.GetCurrency();

            double converted_value = CurrencyConverter.DoExchange(money.Currency, auction_currency, money.Value);
            Money exchaged_money = new Money(auction_currency, converted_value);

            Bid new_bid = new Bid(person, exchaged_money); 
             
            if (!auction.IsBidEligible(new_bid))
            {
                return false;
            } 

            return broker.RegisterBid(new_bid, auction); 
        } 
    }
}
