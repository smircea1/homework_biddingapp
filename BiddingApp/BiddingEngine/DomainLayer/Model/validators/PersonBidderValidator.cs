//-----------------------------------------------------------------------
// <copyright file="PersonBidderValidator.cs" company="Transilvania University of Brasov"> 
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
    /// bidder validator
    /// </summary>
    public static class PersonBidderValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="obj">The person bidder.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// Person is required!
        /// </exception>
        /// <exception cref="Exception">Person is required!</exception>
        public static void ValidateObject(this PersonBidder obj)
        {
            if (obj.IdBidder < 0)
            {
                throw new Exception("Invalid Id!"); 
            }

            if (obj.Person == null)
            {
                throw new Exception("Person is required!");
            }
        }
    }
}
