//-----------------------------------------------------------------------
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
        /// Initializes a new instance of the <see cref="Bid"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="offered">The offered.</param>
        public Bid(Person person, Money offered)
        {
            this.Person = person;
            this.Offered = offered;
        }

        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public Person Person { get; internal set; }

        /// <summary>
        /// Gets the offered.
        /// </summary>
        /// <value>
        /// The offered.
        /// </value>
        public Money Offered { get; internal set; }
    }
}
