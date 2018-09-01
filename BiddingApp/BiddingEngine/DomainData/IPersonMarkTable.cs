//-----------------------------------------------------------------------
// <copyright file="IPersonMarkTable.cs" company="Transilvania University of Brasov"> 
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
    /// The person marks table.
    /// </summary>
    public interface IPersonMarkTable
    {
        /// <summary>
        /// Inserts the person mark.
        /// </summary>
        /// <param name="personMark">The person mark.</param>
        void InsertPersonMark(PersonOfferorMark personMark);

        /// <summary>
        /// Fetches the person marks.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <returns>
        /// All persons marks
        /// </returns>
        List<PersonOfferorMark> FetchPersonOfferorMarks(PersonOfferor offeror);
    }
}
