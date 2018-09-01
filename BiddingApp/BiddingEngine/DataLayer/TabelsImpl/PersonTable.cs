//-----------------------------------------------------------------------
// <copyright file="PersonTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------
 
namespace BiddingApp.BiddingEngine.DataLayer.TabelsImpl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// person table impl.
    /// </summary>
    /// <seealso cref="BiddingApp.BiddingEngine.DomainData.IPersonTable" />
    public class PersonTable : IPersonTable
    {
        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// the person by id
        /// </returns>
        /// <exception cref="NotImplementedException"> not implemented yet.</exception>
        public Person FetchPersonById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>
        /// the inserted id
        /// </returns>
        /// <exception cref="NotImplementedException"> not implemented yet.</exception>
        public int InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
