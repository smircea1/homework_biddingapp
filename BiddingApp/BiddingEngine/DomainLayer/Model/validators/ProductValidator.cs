//-----------------------------------------------------------------------
// <copyright file="ProductValidator.cs" company="Transilvania University of Brasov"> 
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
    /// product validator
    /// </summary>
    public static class ProductValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="obj">The product.</param>
        /// <exception cref="System.Exception">
        /// Invalid Id!
        /// or
        /// Category is requried!
        /// or
        /// Description is requried or is empty!
        /// or
        /// Name is required!
        /// </exception>
        /// <exception cref="Exception">Category is requried!
        /// or
        /// Description is requried or is empty!
        /// or
        /// Name is required!</exception>
        public static void ValidateObject(this Product obj)
        {
            if (obj.Id < 0)
            {
                throw new Exception("Invalid Id!");
            }

            if (string.IsNullOrEmpty(obj.Name))
            {
                throw new Exception("Name is required!");
            }

            if (string.IsNullOrEmpty(obj.Description))
            {
                throw new Exception("Name is required!");
            } 

            if (obj.Category == null)
            {
                throw new Exception("Category is requried!");
            }
        }
    }
}
