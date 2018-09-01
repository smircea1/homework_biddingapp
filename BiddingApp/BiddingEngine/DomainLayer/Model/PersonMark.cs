//-----------------------------------------------------------------------
// <copyright file="PersonMark.cs" company="Transilvania University of Brasov"> 
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
    /// User mark.
    /// </summary>
    public class PersonMark
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonMark"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="receiver">The receiver.</param>
        /// <param name="mark">The mark.</param>
        public PersonMark(Person sender, PersonOfferor receiver, int mark)
        {
            this.Id = 0;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Mark = mark;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
