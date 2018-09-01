//-----------------------------------------------------------------------
// <copyright file="BiddingBroker.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//----------------------------------------------------------------------- 
namespace BiddingApp.BiddingEngine.DomainLayer
{
    using System;
    using System.Collections.Generic;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using BiddingApp.BiddingEngine.DomainLayer.Service.checks;
    using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;

    /// <summary>
    /// The broker that keeps and handles the auctions
    /// </summary>
    public class BiddingBroker
    { 
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         
        /// <summary>
        /// The instance
        /// </summary>
        private static BiddingBroker instance = null;

        /// <summary>
        /// The configs
        /// </summary>
        private static BrokerConfigs configs = BrokerConfigs.LoadConfigs();

        /// <summary>
        /// The domain data storage
        /// </summary>
        private static DomainDataStorage domainDataStorage = DomainDataStorage.GetInstance();

        /// <summary>
        /// The auctions
        /// </summary>
        private readonly List<Auction> auctions = new List<Auction>();

        /// <summary>
        /// Prevents a default instance of the <see cref="BiddingBroker"/> class from being created.
        /// </summary>
        private BiddingBroker()
        {

        }

        /// <summary>
        /// Instances this instance.
        /// </summary>
        /// <returns>The broker instance.</returns>
        public static BiddingBroker Instance()
        {
            if (BiddingBroker.instance == null)
            {
                BiddingBroker.instance = new BiddingBroker();
            }

            return BiddingBroker.instance;
        }


        /// <summary>
        /// Registers the auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>False if the register auction has failed.</returns>
        public bool RegisterAuction(Person person, Auction auction)
        {
            bool canPost = CanAuctionBePostedCheck.DoCheck(person, auction);
            // if it's older
            if (DateTime.Now.CompareTo(auction.StartDate) < 0)
            {
                //// it should not be older than 5 min.
                if ((DateTime.Now - auction.StartDate).TotalMinutes > 5)
                {
                    return false;
                }
            }

            person.GetInProgressAuctions().Add(auction);

            this.auctions.Add(auction);

            return true;
        }

        /// <summary>
        /// Registers the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <param name="auction">The auction.</param>
        /// <returns>false if the bid registration had failed.</returns>
        public bool RegisterBid(Bid bid, Auction auction)
        {
            bool goodBid = CanBidBePostedToActionCheck.DoCheck(bid, auction);

            if (!goodBid)
            {
                //// throw
                return false;
            }

            AuctionService auctionService = new AuctionService(auction);

            if (!auctionService.IsActive)
            {
                //// auction not started or already ended.
                return false;
            }

            domainDataStorage.BidTable.Insert(bid); 

            //// MAYBE NOTICE CURRENT BIDDER HAS CHANGED

            return true;
        }

        /// <summary>
        /// Ends the auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>False if the end auction had failed.</returns>
        public bool EndAuction(PersonOfferor offeror, Auction auction)
        { 
            AuctionService auctionService = new AuctionService(auction); 
            return auctionService.EndAuction(offeror);
        }  

        private void LoadAuctions()
        {
            List<Auction> auctions = domainDataStorage.AuctionTable.FetchAllAuctions();
        }
    }
}
