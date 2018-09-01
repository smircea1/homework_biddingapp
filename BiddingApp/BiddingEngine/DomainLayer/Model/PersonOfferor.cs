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
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Offer role of a person
    /// </summary>
    public class PersonOfferor
    {   
        /// <summary>
        /// Gets or sets the identifier bidder.
        /// </summary>
        /// <value>
        /// The identifier bidder.
        /// </value>
        public int IdOfferor { get; set; }

        /// <summary>
        /// Gets or sets the identifier person.
        /// </summary>
        /// <value>
        /// The identifier person.
        /// </value> 
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the last banned date.
        /// </summary>
        /// <value>
        /// The last banned date.
        /// </value>
        public DateTime LastBannedDate { get; set; }  
    }
}
