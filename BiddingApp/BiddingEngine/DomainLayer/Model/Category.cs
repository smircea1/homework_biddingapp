//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The category of a product
    /// </summary>
    public class Category
    {    
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int IdCategory { get; set; } 

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value> 
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subcategories.
        /// </summary>
        /// <value>
        /// The subcategories.
        /// </value>
        public List<Category> Subcategories { get; set; } = new List<Category>();
    }
}
