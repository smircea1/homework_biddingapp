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
    /// auction validator
    /// </summary>
    public static class AuctionValidator
    {
        /// <summary>
        /// Validates the auction.
        /// </summary>
        /// <param name="obj">The auction.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// Offer person is required!
        /// or
        /// Product is required!
        /// or
        /// Currency is required!
        /// or
        /// StartDate is required!
        /// or
        /// EndDate is required!
        /// or
        /// Start date is after end date!
        /// or
        /// StartValue must be greater than 0!
        /// </exception>
        /// <exception cref="Exception">Offer person is required
        /// or
        /// Product is required
        /// or
        /// Currency is required
        /// or
        /// StartDate is required
        /// or
        /// EndDate is required
        /// or
        /// Start date is after end date!
        /// or
        /// StartValue must be greater than 0</exception>
        public static void ValidateObject(this Auction obj)
        {
            if (obj.IdAuction < 0)
            {
                throw new Exception("Invalid Id!");
            }

            if (obj.PersonOfferor == null)
            {
                throw new Exception("Offer person is required!");
            }

            if (obj.Product == null)
            {
                throw new Exception("Product is required!");
            }

            if (obj.Currency == null)
            {
                throw new Exception("Currency is required!");
            }

            if (obj.StartDate == null)
            {
                throw new Exception("StartDate is required!");
            }

            if (obj.EndDate == null)
            {
                throw new Exception("EndDate is required!");
            }

            if (obj.StartDate.CompareTo(obj.EndDate) >= 0)
            {
                // cannot start after end date or if they are the same.
                throw new Exception("Start date is after end date!");
            }

            if (obj.StartValue < 0)
            {
                throw new Exception("StartValue must be greater than 0!");
            }
        } 
    }
}
