//-----------------------------------------------------------------------
// <copyright file="DomainDataStorage.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------
 
namespace BiddingApp.BiddingEngine.DomainData
{
    using System.Configuration;
    using Insight.Database;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// this is the link between domain and it's storage.
    /// this holds all the tables.
    /// </summary>
    public class DomainDataStorage
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static DomainDataStorage instance = null;

        /// <summary>
        /// The database conneection
        /// </summary>
        private MySqlConnection databaseConneection = null;

        /// <summary>
        /// Prevents a default instance of the <see cref="DomainDataStorage"/> class from being created.
        /// </summary>
        private DomainDataStorage()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            this.databaseConneection = new MySqlConnection(connectionString);

            this.AuctionTable = this.databaseConneection.As<IAuctionTable>();
            this.BidTable = this.databaseConneection.As<IBidTable>();
            this.CategoryTable = this.databaseConneection.As<ICategoryTable>();
            this.CurrencyTable = this.databaseConneection.As<ICurrencyTable>(); 
            this.PersonBidderTable = this.databaseConneection.As<IPersonBidderTable>();
            this.PersonMarkTable = this.databaseConneection.As<IPersonMarkTable>();
            this.PersonOfferorTable = this.databaseConneection.As<IPersonOfferorTable>(); 
            this.PersonTable = this.databaseConneection.As<IPersonTable>();
            this.ProductTable = this.databaseConneection.As<IProductTable>();  
        }

        /// <summary>
        /// Gets the auction table.
        /// </summary>
        /// <value>
        /// The auction table.
        /// </value>
        public IAuctionTable AuctionTable { get; internal set; }

        /// <summary>
        /// Gets the bid table.
        /// </summary>
        /// <value>
        /// The bid table.
        /// </value>
        public IBidTable BidTable { get; internal set; }

        /// <summary>
        /// Gets the category table.
        /// </summary>
        /// <value>
        /// The category table.
        /// </value>
        public ICategoryTable CategoryTable { get; internal set; }

        /// <summary>
        /// Gets the currency table.
        /// </summary>
        /// <value>
        /// The currency table.
        /// </value>
        public ICurrencyTable CurrencyTable { get; internal set; }

        /// <summary>
        /// Gets the person bidder table.
        /// </summary>
        /// <value>
        /// The person bidder table.
        /// </value>
        public IPersonBidderTable PersonBidderTable { get; internal set; }

        /// <summary>
        /// Gets the person mark table.
        /// </summary>
        /// <value>
        /// The person mark table.
        /// </value>
        public IPersonMarkTable PersonMarkTable { get; internal set; }

        /// <summary>
        /// Gets the person offeror table.
        /// </summary>
        /// <value>
        /// The person offeror table.
        /// </value>
        public IPersonOfferorTable PersonOfferorTable { get; internal set; }

        /// <summary>
        /// Gets the person table.
        /// </summary>
        /// <value>
        /// The person table.
        /// </value>
        public IPersonTable PersonTable { get; internal set; }

        /// <summary>
        /// Gets the product table.
        /// </summary>
        /// <value>
        /// The product table.
        /// </value>
        public IProductTable ProductTable { get; internal set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>This class instance</returns>
        public static DomainDataStorage GetInstance()
        {
            if (DomainDataStorage.instance == null)
            {
                DomainDataStorage.instance = new DomainDataStorage();
            }

            return DomainDataStorage.instance;
        }
    }
}
