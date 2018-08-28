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
        /// Inserts the specified auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        void Insert(Auction auction);

        /// <summary>
        /// Updates the specified auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        void Update(Auction auction);
    }
}
