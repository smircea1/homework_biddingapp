//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="Transilvania University of Brasov"> 
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
    /// This is the product that an auction is based on.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        internal Product()
        {
            this.Id = 0;
            this.Categories = new List<Category>();
        }

        /// <summary>
        /// Gets or sets the identifier product.
        /// </summary>
        /// <value>
        /// The identifier product.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Builds an Product
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The pending product to be built
            /// </summary>
            private Product pending;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            public Builder()
            {
                this.pending = new Product();
            }

            /// <summary>
            /// Sets the name.
            /// </summary>
            /// <param name="name">The name.</param>
            public void SetName(string name)
            {
                this.pending.Name = name;
            }

            /// <summary>
            /// Sets the description.
            /// </summary>
            /// <param name="description">The description.</param>
            public void SetDescription(string description)
            {
                this.pending.Description = description;
            }

            /// <summary>
            /// Adds the category.
            /// </summary>
            /// <param name="category">The category.</param>
            public void AddCategory(Category category)
            {
                this.pending.Categories.Add(category);
            }

            /// <summary>
            /// Removes the category.
            /// </summary>
            /// <param name="category">The category.</param>
            public void RemoveCategory(Category category)
            {
                this.pending.Categories.Remove(category);
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>The correctly created product.</returns>
            /// <exception cref="Exception">
            /// product name is empty!
            /// or
            /// No category selected!
            /// </exception>
            public Product Build()
            {
                if (this.pending.Name.Length == 0)
                {
                    throw new Exception("product name is empty!");
                }

                if (this.pending.Description.Length == 0)
                {
                    throw new Exception("description is empty!");
                }

                if (this.pending.Categories.Count == 0)
                {
                    throw new Exception("No category selected!");
                }

                return this.pending;
            }
        }
    }
}
