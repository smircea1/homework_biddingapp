//-----------------------------------------------------------------------
// <copyright file="PersonTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------

namespace BiddingApp.BiddingEngine.DataLayer.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Implementation of IPersonTable.
    /// </summary>
    /// <seealso cref="BiddingApp.BiddingEngine.DomainData.IPersonTable" />
    public class PersonTable : IPersonTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonTable"/> class.
        /// </summary>
        public PersonTable()
        {
        }

        /// <summary>
        /// Inserts the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        public void InsertPerson(Person person)
        { 
        } 

        /// <summary>
        /// Updates the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        public void Update(Person person)
        { 
        }
    }
}
