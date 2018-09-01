//-----------------------------------------------------------------------
// <copyright file="BidValidator.cs" company="Transilvania University of Brasov"> 
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
    /// bid validator
    /// </summary>
    public static class BidValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <exception cref="Exception">
        /// PersonBidder is required!
        /// or
        /// Auction is required!
        /// or
        /// Currency is required!
        /// or
        /// Date is required!
        /// </exception>
        public static void ValidateObject(this Bid bid)
        {
            if (bid.PersonBidder == null)
            {
                throw new Exception("PersonBidder is required!");
            }

            if (bid.Auction == null)
            {
                throw new Exception("Auction is required!");
            }

            if (bid.Currency == null)
            {
                throw new Exception("Currency is required!");
            }

            if (bid.Date == null)
            {
                throw new Exception("Date is required!");
            }
        }
    }
}
