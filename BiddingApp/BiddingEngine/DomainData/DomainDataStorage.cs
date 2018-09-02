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
    public class DomainDataStorage : ITablesProvider
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
        /// The auction table
        /// </summary>
        private IAuctionTable auctionTable;

        /// <summary>
        /// The bid table
        /// </summary>
        private IBidTable bidTable;

        /// <summary>
        /// The category table
        /// </summary>
        private ICategoryTable categoryTable;

        /// <summary>
        /// The currency table
        /// </summary>
        private ICurrencyTable currencyTable;

        /// <summary>
        /// The person bidder table
        /// </summary>
        private IPersonBidderTable personBidderTable;

        /// <summary>
        /// The person mark table
        /// </summary>
        private IPersonMarkTable personMarkTable;

        /// <summary>
        /// The person offeror table
        /// </summary>
        private IPersonOfferorTable personOfferorTable;

        /// <summary>
        /// The person table
        /// </summary>
        private IPersonTable personTable;

        /// <summary>
        /// The product table
        /// </summary>
        private IProductTable productTable;

        /// <summary>
        /// Prevents a default instance of the <see cref="DomainDataStorage"/> class from being created.
        /// </summary>
        private DomainDataStorage()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            this.databaseConneection = new MySqlConnection(connectionString);

            this.auctionTable = this.databaseConneection.As<IAuctionTable>();
            this.bidTable = this.databaseConneection.As<IBidTable>();
            this.categoryTable = this.databaseConneection.As<ICategoryTable>();
            this.currencyTable = this.databaseConneection.As<ICurrencyTable>(); 
            this.personBidderTable = this.databaseConneection.As<IPersonBidderTable>();
            this.personMarkTable = this.databaseConneection.As<IPersonMarkTable>();
            this.personOfferorTable = this.databaseConneection.As<IPersonOfferorTable>(); 
            this.personTable = this.databaseConneection.As<IPersonTable>();
            this.productTable = this.databaseConneection.As<IProductTable>();  
        }
        
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

        /// <summary>
        /// Gets the auction table.
        /// </summary>
        /// <returns>the table</returns>
        public IAuctionTable GetAuctionTable()
        {
            return this.auctionTable;
        }

        /// <summary>
        /// Gets the bid table.
        /// </summary>
        /// <returns>the table</returns>
        public IBidTable GetBidTable()
        {
            return this.bidTable;
        }

        /// <summary>
        /// Gets the category table.
        /// </summary>
        /// <returns>the table</returns>
        public ICategoryTable GetCategoryTable()
        {
            return this.categoryTable;
        }

        /// <summary>
        /// Gets the currency table.
        /// </summary>
        /// <returns>the table</returns>
        public ICurrencyTable GetCurrencyTable()
        {
            return this.currencyTable;
        }

        /// <summary>
        /// Gets the person bidder table.
        /// </summary>
        /// <returns>the table</returns>
        public IPersonBidderTable GetPersonBidderTable()
        {
            return this.personBidderTable;
        }

        /// <summary>
        /// Gets the person mark table.
        /// </summary>
        /// <returns>
        /// the table
        /// </returns>
        public IPersonMarkTable GetPersonMarkTable()
        {
            return this.personMarkTable;
        }

        /// <summary>
        /// Gets the person offeror table.
        /// </summary>
        /// <returns>the table</returns>
        public IPersonOfferorTable GetPersonOfferorTable()
        {
            return this.personOfferorTable;
        }

        /// <summary>
        /// Gets the person table.
        /// </summary>
        /// <returns>the table</returns>
        public IPersonTable GetPersonTable()
        {
            return this.personTable;
        }

        /// <summary>
        /// Gets the product table.
        /// </summary>
        /// <returns>the table</returns>
        public IProductTable GetProductTable()
        {
            return this.productTable;
        }
    }
}
