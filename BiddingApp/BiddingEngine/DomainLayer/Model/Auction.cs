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
        /// Prevents a default instance of the <see cref="Auction"/> class from being created.
        /// </summary>
        private Auction()
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

        /// <summary>
        /// The builder of an auction.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The pending
            /// </summary>
            private Auction pending; 

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            public Builder()
            {
                this.pending = new Auction();
            }

            /// <summary>
            /// Sets the owner.
            /// </summary>
            /// <param name="offeror">The identifier owner.</param>
            public void SetOfferor(PersonOfferor offeror)
            {
                this.pending.PersonOfferor = offeror;
            }

            /// <summary>
            /// Sets the product.
            /// </summary>
            /// <param name="product">The product.</param>
            public void SetProduct(Product product)
            {
                this.pending.Product = product;
            }

            /// <summary>
            /// Sets the currency.
            /// </summary>
            /// <param name="currency">The currency.</param>
            public void SetCurrency(Currency currency)
            {
                this.pending.Currency = currency;
            }

            /// <summary>
            /// Sets the starting value.
            /// </summary> 
            /// <param name="startValue">The start value.</param>
            public void SetStartingValue(double startValue)
            { 
                this.pending.StartValue = startValue;
            }

            /// <summary>
            /// Sets the start date.
            /// </summary>
            /// <param name="start">The start.</param>
            public void SetStartDate(DateTime start)
            {
                this.pending.StartDate = start;
            }

            /// <summary>
            /// Sets the end date.
            /// </summary>
            /// <param name="end">The end.</param>
            public void SetEndDate(DateTime end)
            {
                this.pending.EndDate = end;
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>The just created auction.</returns>
            /// <exception cref="Exception">
            /// you must provide an action owner!
            /// or
            /// you must provide a product to the auction!
            /// or
            /// invalid start/end dates!
            /// or
            /// negative price is not allowed!
            /// </exception>
            public Auction Build()
            {
                if (this.pending.PersonOfferor == null)
                {
                    throw new Exception("you must provide an action offeror!");
                }

                if (this.pending.Product == null)
                {
                    throw new Exception("you must provide a product to the auction!");
                }

                DateTime dateStart = this.pending.StartDate;
                DateTime dateEnd = this.pending.EndDate;

                if (dateStart == null || dateEnd == null)
                {
                    throw new Exception("dates are not set!");
                }

                if (dateStart.CompareTo(dateEnd) >= 0)
                {
                    // cannot start after end date or if they are the same.
                    throw new Exception("invalid start/end dates!");
                }

                if (this.pending.Currency == null)
                {
                    throw new Exception("Currency not set!");
                }

                if (this.pending.StartValue < 0)
                {
                    throw new Exception("negative price is not allowed!");
                } 

                return this.pending;
            }
        }
    }
}
