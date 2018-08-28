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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The category of a product
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The subcategories
        /// </summary>
        private List<Category> subcategories = new List<Category>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Category(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; internal set; }
         
        /// <summary>
        /// Gets the sub categories.
        /// </summary>
        /// <returns>The subcategories.</returns>
        public List<Category> GetSubCategories()
        {
            return this.subcategories;
        }

        /// <summary>
        /// Adds the subcategory.
        /// </summary>
        /// <param name="category">The category.</param>
        public void AddSubcategory(Category category)
        {
            this.subcategories.Add(category);
        }

        /// <summary>
        /// Removes the subcategory.
        /// </summary>
        /// <param name="category">The category.</param>
        public void RemoveSubcategory(Category category)
        {
            this.subcategories.Remove(category);
        }
    }
}
