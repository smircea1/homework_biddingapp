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
    /// Tests if an offeror can close a certain auction
    /// </summary>
    public class CanOfferorEndAuctionCheck
    {
        /// <summary>
        /// Does the check.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <param name="auction">The auction.</param>
        /// <exception cref="System.Exception">
        /// Offeror is null!
        /// or
        /// Offeror does not have enough privileges for this!
        /// or
        /// Auction is already ended!
        /// </exception>
        public static void DoCheck(PersonOfferor offeror, AuctionService auction)
        {
            if (offeror == null)
            {
                throw new Exception("Offeror is null!");
            }

            if (offeror.IdOfferor != auction.Auction.PersonOfferor.IdOfferor)
            {
                // does not belongs to.
                throw new Exception("Offeror does not have enough privileges for this!"); 
            }

            if (auction.HadEnded)
            {
                throw new Exception("Auction is already ended!");
            } 
        }
    }
}
