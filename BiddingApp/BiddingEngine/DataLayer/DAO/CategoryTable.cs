//-----------------------------------------------------------------------
// <copyright file="CategoryTable.cs" company="Transilvania University of Brasov"> 
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
    /// Implementation of ICategoryTable.
    /// </summary>
    /// <seealso cref="BiddingApp.BiddingEngine.DomainData.ICategoryTable" />
    public class CategoryTable : ICategoryTable
    {
        /// <summary>
        /// Inserts the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void Insert(Category category)
        { 
        }

        /// <summary>
        /// Updates the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        public void Update(Category category)
        { 
        }
    }
}
