//-----------------------------------------------------------------------
// <copyright file="IAuctionTable.cs" company="Transilvania University of Brasov"> 
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
    /// Auction table that would be used into service
    /// </summary>
    public interface IAuctionTable
    {
        /// <summary>
        /// Inserts the auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>the just inserted id</returns>
        void InsertAuction(Auction auction);

        /// <summary>
        /// Updates the auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        void UpdateAuction(Auction auction);

        /// <summary>
        /// Fetches the auction by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the selected auction or null</returns>
        Auction FetchAuctionById(int id);

        /// <summary>
        /// Fetches the offeror auctions.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <returns>offeror's auctions</returns>
        List<Auction> FetchOfferorAuctions(PersonOfferor offeror);

        /// <summary>
        /// Fetches all auctions.
        /// </summary>
        /// <returns>all auctions existing.</returns>
        List<Auction> FetchAllAuctions();

        /// <summary>
        /// Fetches the offeror auctions by category.
        /// </summary>
        /// <param name="offerer">The offerer.</param>
        /// <param name="category">The category.</param>
        /// <returns>returns all user's auction is specified category</returns>
        List<Auction> FetchOfferorAuctionsByCategory(PersonOfferor offerer, Category category);
    }
}
