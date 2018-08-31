//-----------------------------------------------------------------------
// <copyright file="PersonBidder.cs" company="Transilvania University of Brasov"> 
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
    /// The bidder role of a person
    /// </summary>
    public class PersonBidder
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBidder"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonBidder(Person person)
        {
            this.Person = person;
        }

        /// <summary>
        /// Gets or sets the identifier bidder.
        /// </summary>
        /// <value>
        /// The identifier bidder.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier person.
        /// </summary>
        /// <value>
        /// The identifier person.
        /// </value>
        public Person Person { get; set; }
    }
}
