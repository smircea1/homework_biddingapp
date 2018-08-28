//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Transilvania University of Brasov"> 
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
    /// This represents a money currency
    /// </summary>
    public class Currency 
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rate">The rate.</param>
        public Currency(string name, double rate)
        {
            this.Name = name;
            this.Rate = rate;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public double Rate { get; internal set; }
    }
}
