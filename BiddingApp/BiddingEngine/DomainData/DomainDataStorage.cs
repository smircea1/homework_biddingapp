//-----------------------------------------------------------------------
// <copyright file="DomainDataStorage.cs" company="Transilvania University of Brasov"> 
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
    using BiddingApp.BiddingEngine.DataLayer.DAO;

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
        /// Prevents a default instance of the <see cref="DomainDataStorage"/> class from being created.
        /// </summary>
        private DomainDataStorage()
        {
            this.AuctionTable = new AuctionTable();
        }

        /// <summary>
        /// Gets the auction table.
        /// </summary>
        /// <value>
        /// The auction table.
        /// </value>
        public IAuctionTable AuctionTable { get; internal set; }

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
