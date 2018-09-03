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
        /// <param name="idPerson">The identifier person.</param>
        /// <param name="personBidder">The person bidder.</param>
        void InsertPersonBidder(int idPerson, PersonBidder personBidder);

        /// <summary>
        /// Fetches the person bidder by person.
        /// </summary>
        /// <param name="idPerson">The identifier person.</param>
        /// <returns>
        /// the bidder found
        /// </returns>
        PersonBidder FetchPersonBidderByIdPerson(int idPerson);

        /// <summary>
        /// Fetches the person by identifier bid.
        /// </summary>
        /// <param name="idBid">The identifier bid.</param>
        /// <returns>the owner of the bid.</returns>
        PersonBidder FetchPersonByIdBid(int idBid);
    }
}
