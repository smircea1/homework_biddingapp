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
        /// <param name="obj">The bid.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// PersonBidder is required!
        /// or
        /// Auction is required!
        /// or
        /// Currency is required!
        /// or
        /// Date is required!
        /// </exception>
        /// <exception cref="Exception">PersonBidder is required!
        /// or
        /// Auction is required!
        /// or
        /// Currency is required!
        /// or
        /// Date is required!</exception>
        public static void ValidateObject(this Bid obj)
        {
            if (obj.IdBid < 0)
            {
                throw new Exception("Invalid Id!");
            }

            if (obj.PersonBidder == null)
            {
                throw new Exception("PersonBidder is required!");
            }

            if (obj.Auction == null)
            {
                throw new Exception("Auction is required!");
            }

            if (obj.Currency == null)
            {
                throw new Exception("Currency is required!");
            }

            if (obj.Date == null)
            {
                throw new Exception("Date is required!");
            }
        }
    }
}
