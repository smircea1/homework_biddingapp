//-----------------------------------------------------------------------
// <copyright file="IProductTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------

namespace BiddingApp.BiddingEngine.DomainData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Product table that would be used into service
    /// </summary>
    public interface IProductTable
    {
        /// <summary>
        /// Inserts the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Insert(Product product);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Update(Product product);
    }
}
