//-----------------------------------------------------------------------
// <copyright file="ProductTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------

namespace BiddingApp.BiddingEngine.DataLayer.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Implementation of IProductTable.
    /// </summary>
    /// <seealso cref="BiddingApp.BiddingEngine.DomainData.IProductTable" />
    public class ProductTable : IProductTable
    {
        /// <summary>
        /// Inserts the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Insert(Product product)
        { 
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Update(Product product)
        { 
        }
    }
}
