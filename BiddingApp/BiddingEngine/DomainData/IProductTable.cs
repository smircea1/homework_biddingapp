﻿//-----------------------------------------------------------------------
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
        /// Inserts the product.
        /// </summary>
        /// <param name="idCategory">The identifier category.</param>
        /// <param name="product">The product.</param>
        void InsertProduct(int idCategory, Product product);

        /// <summary>
        /// Fetches the product by all attributes.
        /// </summary>
        /// <param name="idCategory">The identifier category.</param>
        /// <param name="product">The product.</param>
        /// <returns>
        /// the product with ID
        /// </returns>
        Product FetchProductByAllAttributes(int idCategory, Product product); 

        /// <summary>
        /// Fetches all products.
        /// </summary>
        /// <returns>all products from DB.</returns>
        List<Product> FetchAllProducts();
    }
}
