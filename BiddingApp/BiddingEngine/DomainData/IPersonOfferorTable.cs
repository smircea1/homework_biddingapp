//-----------------------------------------------------------------------
// <copyright file="IPersonOfferorTable.cs" company="Transilvania University of Brasov"> 
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
    /// Person offeror table interface.
    /// </summary>
    public interface IPersonOfferorTable
    {
        /// <summary>
        /// Inserts the person bidder.
        /// </summary>
        /// <param name="idPerson">The identifier person.</param>
        /// <param name="personOfferor">The person offeror.</param>
        void InsertPersonOfferor(int idPerson, PersonOfferor personOfferor);

        /// <summary>
        /// Updates the person offeror.
        /// </summary>
        /// <param name="personOfferor">The person offeror.</param>
        void UpdatePersonOfferor(PersonOfferor personOfferor);

        /// <summary>
        /// Fetches the person bidder by person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>
        /// the offeror role of the person
        /// </returns>
        PersonOfferor FetchPersonOfferorByPerson(Person person); 
    }
}
