//-----------------------------------------------------------------------
// <copyright file="AuctionValidator.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// validates this obj.
    /// </summary>
    public static class AuctionValidator
    {
        /// <summary>
        /// Validates the dates.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <exception cref="Exception">Start date is after end date!</exception>
        public static void ValidateDates(this Auction auction)
        {
            DateTime dateStart = auction.StartDate;
            DateTime dateEnd = auction.EndDate;

            if (dateStart.CompareTo(dateEnd) >= 0)
            {
                // cannot start after end date or if they are the same.
                throw new Exception("Start date is after end date!");
            }
        }
    }
}
