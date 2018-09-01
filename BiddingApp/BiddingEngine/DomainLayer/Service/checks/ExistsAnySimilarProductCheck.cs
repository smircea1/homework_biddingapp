﻿//-----------------------------------------------------------------------
// <copyright file="ExistsAnySimilarProductCheck.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   


namespace BiddingApp.BiddingEngine.DomainLayer.Service.checks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;

    /// <summary>
    /// checks if the product already exists.
    /// </summary>
    class ExistsAnySimilarProductCheck
    {
        public static bool DoCheck(Product product)
        {
            IProductTable table = DomainDataStorage.GetInstance().ProductTable;
            List<Product> existingProducts = table.FetchAllProducts();

            ProductService productService = new ProductService(product);
            
            return productService.HasSimilarDescriptionToAnyFrom(existingProducts);
        }
    }
}
