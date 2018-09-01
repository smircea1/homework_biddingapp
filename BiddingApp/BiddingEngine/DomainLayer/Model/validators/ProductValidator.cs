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
        /// <param name="product">The product.</param>
        /// <exception cref="Exception">
        /// Category is requried!
        /// or
        /// Description is requried or is empty!
        /// or
        /// Name is required!
        /// </exception>
        public static void ValidateObject(this Product product)
        {
            if(product.Category == null)
            {
                throw new Exception("Category is requried!");
            }

            if (product.Description == null || product.Description.Length == 0)
            {
                throw new Exception("Description is requried or is empty!");
            }

            if (product.Name == null)
            {
                throw new Exception("Name is required!");
            }
        }
    }
}
