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
            this.PersonOfferor = null;
            this.Product = null;
            this.Currency = null;
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
        [Required(ErrorMessage = "PersonOfferor is required")]
        public PersonOfferor PersonOfferor { get; set; }

        /// <summary>
        /// Gets or sets the identifier product.
        /// </summary>
        /// <value>
        /// The identifier product.
        /// </value>
        [Required(ErrorMessage = "Product is required")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the identifier currency.
        /// </summary>
        /// <value>
        /// The identifier currency.
        /// </value>
        [Required(ErrorMessage = "Currency is required")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>
        /// The start value.
        /// </value>
        [Required(ErrorMessage = "StartValue is required")]
        [Range(0, 100, ErrorMessage = "StartValue must be between $1 and $100")]
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
