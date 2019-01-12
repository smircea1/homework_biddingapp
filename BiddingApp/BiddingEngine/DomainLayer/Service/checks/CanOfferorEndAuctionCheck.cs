//-----------------------------------------------------------------------
// <copyright file="CanOfferorEndAuctionCheck.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   

namespace BiddingApp.BiddingEngine.DomainLayer.Service.Checks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;

    /// <summary>
    /// Tests if an offer person can close a certain auction
    /// </summary>
    public class CanOfferorEndAuctionCheck
    {
        /// <summary>
        /// Does the check.
        /// </summary>
        /// <param name="offerPerson">The offer person.</param>
        /// <param name="auction">The auction.</param>
        /// <exception cref="System.Exception">
        /// offer person is null!
        /// or
        /// offer person does not have enough privileges for this!
        /// or
        /// Auction is already ended!
        /// </exception>
        public static void DoCheck(PersonOfferor offerPerson, AuctionService auction)
        {
            if (offerPerson == null)
            {
                throw new Exception("offer person is null!");
            }

            if (offerPerson.IdOfferor != auction.Auction.PersonOfferor.IdOfferor)
            {
                // does not belongs to.
                throw new Exception("offer person does not have enough privileges for this!"); 
            }

            if (auction.HadEnded)
            {
                throw new Exception("Auction is already ended!");
            } 
        }
    }
}
