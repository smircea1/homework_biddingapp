//-----------------------------------------------------------------------
// <copyright file="Auction.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An auction
    /// </summary>
    public class Auction
    {  
        /// <summary>
        /// Gets or sets the identifier auction.
        /// </summary>
        /// <value>
        /// The identifier auction.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier offeror.
        /// </summary>
        /// <value>
        /// The identifier offeror.
        /// </value> 
        public PersonOfferor PersonOfferor { get; set; }

        /// <summary>
        /// Gets or sets the identifier product.
        /// </summary>
        /// <value>
        /// The identifier product.
        /// </value> 
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the identifier currency.
        /// </summary>
        /// <value>
        /// The identifier currency.
        /// </value> 
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value> 
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value> 
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>
        /// The start value.
        /// </value> 
        public double StartValue { get; set; }  
    } 
}
