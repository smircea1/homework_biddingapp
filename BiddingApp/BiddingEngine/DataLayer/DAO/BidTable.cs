//-----------------------------------------------------------------------
// <copyright file="BidTable.cs" company="Transilvania University of Brasov"> 
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
    /// Implementation of IBidTable.
    /// </summary>
    /// <seealso cref="BiddingApp.BiddingEngine.DomainData.IBidTable" />
    public class BidTable : IBidTable
    {
        /// <summary>
        /// Inserts the specified bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        public void Insert(Bid bid)
        {
        }

        /// <summary>
        /// Updates the specified bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        public void Update(Bid bid)
        {
        }
    }
}
