//-----------------------------------------------------------------------
// <copyright file="Money.cs" company="Transilvania University of Brasov"> 
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
    /// The money for bidding
    /// </summary>
    public class Money
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <param name="value">The value.</param>
        public Money(Currency currency, double value)
        {
            this.Currency = currency;
            this.Value = value;
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public Currency Currency { get; internal set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; internal set; }
    }
}
