//-----------------------------------------------------------------------
// <copyright file="CanBidBePostedToActionCheck.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   

namespace BiddingApp.BiddingEngine.DomainLayer.Service.Checks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;

    /// <summary>
    /// this is the check in order to allow a bid occur.
    /// </summary>
    public class CanBidBePostedToActionCheck
    {
        /// <summary>
        /// Initializes the <see cref="CanBidBePostedToActionCheck" /> class.
        /// </summary>
        /// <param name="personBidder">The person bidder.</param>
        /// <param name="bid">The bid.</param>
        /// <param name="auction">The auction.</param>
        /// <param name="highest_bid">The highest bid.</param>
        /// <returns>
        /// true if the bid can be posted to auction
        /// </returns>
        public static bool DoCheck(PersonBidder personBidder, Bid bid, Auction auction, Bid highest_bid)
        {    
            AuctionService auctionService = new AuctionService(auction);

            //// is active (started & not ended)? 
            if (!auctionService.IsActive)
            {
                return false;
            }

            //// they are in the same currency?
            if (!bid.Currency.Equals(auction.Currency))
            {
                return false;
            }

            double highest_value;

            //// there is no bid & this bid value is bigger than auction start value.
            if (highest_bid == null)
            {
                highest_value = auction.StartValue;
            } 
            else
            { // null Person Bidder
                if (highest_bid.PersonBidder == null)
                {
                    return false;
                }

                // bid his bid?
                if (highest_bid.PersonBidder.IdBidder == bid.PersonBidder.IdBidder)
                {
                    return false;
                }

                highest_value = highest_bid.Value;
            }   

            double incoming_value = bid.Value;

            //// Max current price + 50% * current price
            double max_new_bid_value = highest_value + (highest_value / 2);

            //// Price should be bigger than existent higher one, but not bigger with 50% of the existent
            bool price_ok = incoming_value > highest_value && incoming_value < max_new_bid_value;

            return price_ok;
        } 
    }
}
