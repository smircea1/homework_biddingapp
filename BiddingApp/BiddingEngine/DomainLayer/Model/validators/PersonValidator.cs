//-----------------------------------------------------------------------
// <copyright file="PersonValidator.cs" company="Transilvania University of Brasov"> 
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
    /// person validator
    /// </summary>
    public static class PersonValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="obj">The person.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// Name is required!
        /// </exception>
        /// <exception cref="Exception">Name is required</exception>
        public static void ValidateObject(this Person obj)
        {
            if (obj.IdPerson < 0)
            {
                throw new Exception("Invalid Id!");
            }

            if (string.IsNullOrWhiteSpace(obj.Name))
            {
                throw new Exception("Name is required!");
            }

            if (string.IsNullOrWhiteSpace(obj.Phone))
            {
                throw new Exception("Phone is required!");
            }
        }
    }
}
