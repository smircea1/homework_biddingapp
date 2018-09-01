//-----------------------------------------------------------------------
// <copyright file="IPersonTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------

namespace BiddingApp.BiddingEngine.DomainData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Person table that would be used into service
    /// </summary>
    public interface IPersonTable
    {
        /// <summary>
        /// Inserts the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>the inserted id</returns>
        int InsertPerson(Person person);

        /// <summary>
        /// Updates the person.
        /// </summary>
        /// <param name="person">The person.</param>
        void UpdatePerson(Person person);
         
        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the person by id</returns>
        Person FetchPersonById(int id);
    }
}
