//-----------------------------------------------------------------------
// <copyright file="ITablesProvider.cs" company="Transilvania University of Brasov"> 
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

    /// <summary>
    /// provides tables
    /// </summary>
    public interface ITablesProvider
    {
        /// <summary>
        /// Gets the person mark table.
        /// </summary>
        /// <returns>the table or null</returns>
        IPersonMarkTable GetPersonMarkTable();

        /// <summary>
        /// Gets the person table.
        /// </summary>
        /// <returns>the table or null</returns>
        IPersonTable GetPersonTable();

        /// <summary>
        /// Gets the offer person table.
        /// </summary>
        /// <returns>the table or null</returns>
        IPersonOfferorTable GetPersonOfferorTable();

        /// <summary>
        /// Gets the person bidder table.
        /// </summary>
        /// <returns>the table or null</returns>
        IPersonBidderTable GetPersonBidderTable();

        /// <summary>
        /// Gets the category table.
        /// </summary>
        /// <returns>the table or null</returns>
        ICategoryTable GetCategoryTable();

        /// <summary>
        /// Gets the product table.
        /// </summary>
        /// <returns>the table or null</returns>
        IProductTable GetProductTable();

        /// <summary>
        /// Gets the currency table.
        /// </summary>
        /// <returns>the table or null</returns>
        ICurrencyTable GetCurrencyTable();

        /// <summary>
        /// Gets the bid table.
        /// </summary>
        /// <returns>the table or null</returns>
        IBidTable GetBidTable();

        /// <summary>
        /// Gets the auction table.
        /// </summary>
        /// <returns>the table or null</returns>
        IAuctionTable GetAuctionTable();
    }
}
