//-----------------------------------------------------------------------
// <copyright file="AuctionTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DataLayer.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Implementation of IAuctionTable.
    /// </summary>
    /// <seealso cref="BiddingApp.BiddingEngine.DomainData.IAuctionTable" />
    public class AuctionTable : IAuctionTable
    {
        /// <summary>
        /// Inserts the specified auction.
        /// </summary>
        /// <param name="auction">The auction.</param> 
        public void Insert(Auction auction)
        { 
        }

        /// <summary>
        /// Updates the specified auction.
        /// </summary>
        /// <param name="auction">The auction.</param> 
        public void Update(Auction auction)
        { 
        }
    }
}
