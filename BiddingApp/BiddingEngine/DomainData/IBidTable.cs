//-----------------------------------------------------------------------
// <copyright file="IBidTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Bid table that would be used into service
    /// </summary>
    public interface IBidTable
    {
        /// <summary>
        /// Inserts the specified bid.
        /// </summary>
        /// <param name="idBidder">The identifier bidder.</param>
        /// <param name="idAuction">The identifier auction.</param>
        /// <param name="idCurrency">The identifier currency.</param>
        /// <param name="bid">The bid.</param>
        void InsertBid(int idBidder, int idAuction, int idCurrency, Bid bid);

        /// <summary>
        /// Fetches the bid by identifier bid.
        /// </summary>
        /// <param name="idBid">The identifier bid.</param>
        /// <returns>found or null bid.</returns>
        Bid FetchBidByIdBid(int idBid);

        /// <summary>
        /// Fetches the auction highest bid.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>the highest bid of the auction</returns>
        Bid FetchAuctionHighestBid(Auction auction);

        /// <summary>
        /// Fetches the auction bidds.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>All auction's bidds.</returns>
        List<Bid> FetchAuctionBidds(Auction auction);
    }
}
