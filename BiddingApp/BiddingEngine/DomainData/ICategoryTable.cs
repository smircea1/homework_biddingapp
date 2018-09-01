//-----------------------------------------------------------------------
// <copyright file="ICategoryTable.cs" company="Transilvania University of Brasov"> 
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
    /// Category table that would be used into service
    /// </summary>
    public interface ICategoryTable
    {
        /// <summary>
        /// Inserts the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>the just inserted id</returns>
        void InsertCategory(Category category);

        /// <summary>
        /// Fetches all categories.
        /// </summary>
        /// <returns>All available categories</returns>
        List<Category> FetchAllCategories();

        /// <summary>
        /// Fetches the sub categories.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Category's subcategories.</returns>
        List<Category> FetchSubCategories(Category category);
    }
}
