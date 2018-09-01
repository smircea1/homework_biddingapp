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
        /// <param name="person">The person.</param>
        /// <exception cref="Exception">Name is required</exception>
        public static void ValidateObject(this Person person)
        {
            if (person.Name == null)
            {
                throw new Exception("Name is required!");
            }
        }
    }
}
