//-----------------------------------------------------------------------
// <copyright file="PostAuctionToBrokerCheck.cs" company="Transilvania University of Brasov"> 
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

    /// <summary>
    /// this is the check in order to post an auction
    /// </summary>
    public class PostAuctionToBrokerCheck
    {

        /// <summary>
        /// Does the check.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns></returns>
        public static bool DoCheck(Auction auction)
        {
            // if it's older
            if (DateTime.Now.CompareTo(auction.StartDate) < 0)
            {
                //// it should not be older than 5 min.
                if ((DateTime.Now - auction.StartDate).TotalMinutes > 5)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
