//-----------------------------------------------------------------------
// <copyright file="PersonOfferor.cs" company="Transilvania University of Brasov"> 
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
    /// The Offer role of a person
    /// </summary>
    public class PersonOfferor
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonOfferor"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonOfferor(Person person)
        {
            this.Id = 0;
            this.Person = person;
            this.AuctionsInProgress = new List<Auction>();
            this.AuctionsFinished = new List<Auction>();
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
         
        /// <summary>
        /// Gets or sets the auctions in progress.
        /// </summary>
        /// <value>
        /// The auctions in progress.
        /// </value>
        public List<Auction> AuctionsInProgress { get; set; }

        /// <summary>
        /// Gets or sets the auctions finished.
        /// </summary>
        /// <value>
        /// The auctions finished.
        /// </value>
        public List<Auction> AuctionsFinished { get; set; }
    }
}
