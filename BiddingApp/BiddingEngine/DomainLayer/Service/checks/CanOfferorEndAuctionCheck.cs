//-----------------------------------------------------------------------
// <copyright file="CanOfferorEndAuctionCheck.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   

namespace BiddingApp.BiddingEngine.DomainLayer.Service.checks
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
    class CanOfferorEndAuctionCheck
    {
        public static bool DoCheck(PersonOfferor offeror, AuctionService auction)
        {
            if (offeror == null)
            {
                return false;
            }

            if (offeror.Id != auction.Auction.PersonOfferor.Id)
            {
                // does not belongs to.
                return false;
            }

            if (auction.HadEnded)
            {
                return false;
            }

            return true;
        }
    }
}
