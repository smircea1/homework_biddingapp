//-----------------------------------------------------------------------
// <copyright file="PersonOfferorMarkValidator.cs" company="Transilvania University of Brasov"> 
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
    /// Offer person mark validator
    /// </summary>
    public static class PersonOfferorMarkValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="obj">The offer person mark.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// Sender is required!
        /// or
        /// Receiver is required!
        /// or
        /// Sender is required!
        /// or
        /// Mark is out of range(0, 100)!
        /// or
        /// DateOccur is required!
        /// </exception>
        /// <exception cref="Exception">Sender is required!
        /// or
        /// Receiver is required!
        /// or
        /// Sender is required!
        /// or
        /// Mark is out of range(0, 100)!
        /// or
        /// DateOccur is required!</exception>
        public static void ValidateObject(this PersonOfferorMark obj)
        {
            if (obj.IdOfferorMark < 0)
            {
                throw new Exception("Invalid Id!");
            }

            if (obj.Sender == null)
            {
                throw new Exception("Sender is required!");
            }

            if (obj.Receiver == null)
            {
                throw new Exception("Receiver is required!");
            }

            if (obj.Sender == null)
            {
                throw new Exception("Sender is required!");
            }

            if (obj.Mark <= 0 || obj.Mark > 10)
            {
                throw new Exception("Mark is out of range(1, 10)!");
            } 
        }
    }
}
