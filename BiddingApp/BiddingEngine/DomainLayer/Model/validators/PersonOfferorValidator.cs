//-----------------------------------------------------------------------
// <copyright file="PersonOfferorValidator.cs" company="Transilvania University of Brasov"> 
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
    /// offeror validator
    /// </summary>
    public static class PersonOfferorValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="personOfferor">The person offeror.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// Person is required!
        /// </exception>
        /// <exception cref="Exception">Person is required!</exception>
        public static void ValidateObject(this PersonOfferor personOfferor)
        {
            if (personOfferor.Id < 0)
            {
                throw new Exception("Invalid Id!"); 
            }

            if (personOfferor.Person == null)
            {
                throw new Exception("Person is required!");
            }
        }
    }
}
