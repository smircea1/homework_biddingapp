//-----------------------------------------------------------------------
// <copyright file="PersonService.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Wraps a person to be used into service
    /// </summary>
    public class PersonService
    {  
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonService(Person person)
        {
            this.Person = person; 
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public Person Person { get; internal set; } 
    }
}
