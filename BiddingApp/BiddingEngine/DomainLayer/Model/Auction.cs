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
        /// Initializes a new instance of the <see cref="Auction"/> class.
        /// </summary>
        public Auction()
        {
            this.Id = 0; 
            this.StartValue = 0;
        }

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

        /// <summary>
        /// Validates the dates.
        /// </summary>
        /// <returns>If this Action has valide dates</returns>
        public bool ValidateDates()
        {
            // TODO: implement this
            return true;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    } 
}
