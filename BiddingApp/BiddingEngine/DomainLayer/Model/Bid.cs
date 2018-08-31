﻿//-----------------------------------------------------------------------
// <copyright file="Bid.cs" company="Transilvania University of Brasov"> 
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
    /// An auction bid
    /// </summary>
    public class Bid
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="Bid"/> class from being created.
        /// </summary>
        private Bid()
        {
            this.Id = 0;
            this.PersonBidder = null;
            this.Auction = null;
            this.Currency = null;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier owner.
        /// </summary>
        /// <value>
        /// The identifier owner.
        /// </value>
        public PersonBidder PersonBidder { get; set; }

        /// <summary>
        /// Gets or sets the identifier auction.
        /// </summary>
        /// <value>
        /// The identifier auction.
        /// </value>
        public Auction Auction { get; set; }

        /// <summary>
        /// Gets or sets the identifier currency.
        /// </summary>
        /// <value>
        /// The identifier currency.
        /// </value>
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }
    }
}
