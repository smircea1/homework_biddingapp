//-----------------------------------------------------------------------
// <copyright file="CategoryValidator.cs" company="Transilvania University of Brasov"> 
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
    /// category validator
    /// </summary>
    public static class CategoryValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <exception cref="Exception">Name is required!</exception>
        public static void ValidateObject(this Category category)
        {
            if(category.Name == null)
            {
                throw new Exception("Name is required!");
            }
        }
    }
}
