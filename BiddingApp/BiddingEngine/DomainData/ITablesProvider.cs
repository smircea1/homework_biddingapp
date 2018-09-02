

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
        /// <returns>the table</returns>
        IPersonMarkTable GetPersonMarkTable();

        /// <summary>
        /// Gets the person table.
        /// </summary>
        /// <returns></returns>
        IPersonTable GetPersonTable();

        /// <summary>
        /// Gets the person offeror table.
        /// </summary>
        /// <returns></returns>
        IPersonOfferorTable GetPersonOfferorTable();

        /// <summary>
        /// Gets the person bidder table.
        /// </summary>
        /// <returns></returns>
        IPersonBidderTable GetPersonBidderTable();

        /// <summary>
        /// Gets the category table.
        /// </summary>
        /// <returns></returns>
        ICategoryTable GetCategoryTable();

        /// <summary>
        /// Gets the product table.
        /// </summary>
        /// <returns></returns>
        IProductTable GetProductTable();

        /// <summary>
        /// Gets the currency table.
        /// </summary>
        /// <returns></returns>
        ICurrencyTable GetCurrencyTable();

        /// <summary>
        /// Gets the bid table.
        /// </summary>
        /// <returns></returns>
        IBidTable GetBidTable();

        /// <summary>
        /// Gets the auction table.
        /// </summary>
        /// <returns></returns>
        IAuctionTable GetAuctionTable();
    }
}
