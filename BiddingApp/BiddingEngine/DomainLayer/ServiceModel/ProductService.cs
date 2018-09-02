//-----------------------------------------------------------------------
// <copyright file="ProductService.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using BiddingApp.BiddingEngine.DomainLayer.Service.Utils;

    /// <summary>
    /// Wraps an product for the service.
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// The except chars
        /// </summary>
        private static readonly char[] LevensteinExceptChars = { '.', ',', ':', '?', '!' };

        /// <summary>
        /// The level for string duplicate
        /// </summary>
        private static readonly int LevelForStringDuplicate = int.Parse(ConfigurationManager.AppSettings.Get("LevelForStringDuplicate"));

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public ProductService(Product product)
        {
            this.Product = product;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public Product Product { get; internal set; }
         
        /// <summary>
        /// Prepares the description for levenstein.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>returns the string lowered without exception chars.</returns>
        public static string PrepareDescriptionForLevenstein(string input)
        {
            string result = input;

            result = result.ToLower();

            result = RemoveCharsFromString(result, LevensteinExceptChars);

            return result;
        }

        /// <summary>
        /// Removes the chars from string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="oldChar">The old character.</param>
        /// <returns>returns the string without the specified chars.</returns>
        public static string RemoveCharsFromString(string source, char[] oldChar)
        {
            return string.Join(string.Empty, source.ToCharArray().Where(a => !oldChar.Contains(a)).ToArray());
        }

        /// <summary>
        /// Determines whether [is duplicate in] [the specified products].
        /// </summary>
        /// <param name="products">The products.</param>
        /// <returns>
        ///   <c>true</c> if [is duplicate in] [the specified products]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasSimilarDescriptionToAnyFrom(List<Product> products)
        {
            string actual_description = PrepareDescriptionForLevenstein(this.Product.Description);

            foreach (Product list_product in products)
            {
                string list_product_description = PrepareDescriptionForLevenstein(list_product.Description);

                if (LevenshteinDistance.ComputeDistance(actual_description, list_product_description) < LevelForStringDuplicate)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
