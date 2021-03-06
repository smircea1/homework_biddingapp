﻿//-----------------------------------------------------------------------
// <copyright file="PersonOfferorMark.cs" company="Transilvania University of Brasov"> 
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
    /// User mark.
    /// </summary>
    public class PersonOfferorMark
    {   
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int IdOfferorMark { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value> 
        public Person Sender { get; set; }

        /// <summary>
        /// Gets or sets the receiver.
        /// </summary>
        /// <value>
        /// The receiver.
        /// </value> 
        public PersonOfferor Receiver { get; set; }

        /// <summary>
        /// Gets or sets the mark.
        /// </summary>
        /// <value>
        /// The mark.
        /// </value> 
        public int Mark { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value> 
        public DateTime DateOccur { get; set; }
    }
}
