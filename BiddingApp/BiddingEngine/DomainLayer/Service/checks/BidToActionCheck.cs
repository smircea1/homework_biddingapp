//-----------------------------------------------------------------------
// <copyright file="BidToActionCheck.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   

namespace BiddingApp.BiddingEngine.DomainLayer.Service.checks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// this is the check in order to allow a bid occur.
    /// </summary>
    class BidToActionCheck
    {
        /// <summary>
        /// Initializes the <see cref="BidToActionCheck" /> class.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <param name="auction">The auction.</param>
        public static bool DoCheck(Bid bid, Auction auction)
        {
            DomainDataStorage dataStorage = DomainDataStorage.GetInstance();
            IBidTable bidTable = dataStorage.BidTable;

            Bid highest_bid = bidTable.FetchAuctionHighestBid(auction);

            // bid his bid?
            if (highest_bid.PersonBidder.Id == bid.PersonBidder.Id)
            {
                return false;
            }

            // they are in the same currency?
            if (!bid.Currency.Equals(auction.Currency))
            {
                return false;
            }

            double highest_value = highest_bid.Value;
            double incoming_value = bid.Value;

            //// Max current price + 50% * current price
            double max_new_bid_value = highest_value + (highest_value / 2);

            //// Price should be bigger than existent higher one, but not bigger with 50% of the existent
            bool price_ok = incoming_value > highest_value && incoming_value < max_new_bid_value;

            return price_ok;
        } 
    }
}
