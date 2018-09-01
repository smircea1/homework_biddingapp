//-----------------------------------------------------------------------
// <copyright file="IPersonBidderTable.cs" company="Transilvania University of Brasov"> 
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
    /// Person bidder table interface
    /// </summary>
    public interface IPersonBidderTable
    {
        /// <summary>
        /// Inserts the person bidder.
        /// </summary>
        /// <param name="personBidder">The person bidder.</param>
        void InsertPersonBidder(PersonBidder personBidder);

        /// <summary>
        /// Fetches the person bidder by person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>the bidder found</returns>
        PersonBidder FetchPersonBidderByPerson(Person person);
    }
}
