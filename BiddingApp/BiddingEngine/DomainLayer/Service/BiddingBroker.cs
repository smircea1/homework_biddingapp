﻿//-----------------------------------------------------------------------
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
    using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;

    /// <summary>
    /// The broker that keeps and handles the auctions
    /// </summary>
    public class BiddingBroker
    {
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
        /// Dids the person hit maximum category list limit.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="category">The category.</param>
        /// <returns>true if he did, false either</returns>
        public bool DidPersonHitMaxCategoryListLimit(Person person, Category category)
        {
            PersonService personService = new PersonService(person);
            int max_in_category = BiddingBroker.configs.MaxInProgressByCategory;
            int current_in_category = personService.CountActiveAuctionsInCategory(category);

            return current_in_category >= max_in_category;
        }

        /// <summary>
        /// Dids the person hit maximum list limit.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>true if he did, false either</returns>
        public bool DidPersonHitMaxListLimit(Person person)
        {
            int max_in_progress = BiddingBroker.configs.MaxInProgress;
            int counted_in_progress = person.GetInProgressAuctions().Count;

            return counted_in_progress >= max_in_progress;
        }

        /// <summary>
        /// Registers the auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>False if the register auction has failed.</returns>
        public bool RegisterAuction(Person person, Auction auction)
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
            AuctionService auctionService = new AuctionService(auction);
            if (auctionService.IsEnded)
            {
                return false;
            }

            auctionService.Auction.HistoryBids.Add(auction.CurrentBid);
            auction.CurrentBid = bid;

            //// NOTICE CURRENT BIDDER HAS CHANGED

            return true;
        }

        /// <summary>
        /// Ends the auction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>False if the end auction had failed.</returns>
        public bool EndAuction(Person owner, Auction auction)
        { 
            if (!owner.GetInProgressAuctions().Remove(auction))
            {
                return false; // cannot remove auction, it may didn't exist.
            }

            owner.GetFinishedAuctions().Add(auction);

            return true;
        }  

        private void LoadAuctions()
        {
            List<Auction> auctions = domainDataStorage.AuctionTable.FetchAllAuctions();
        }
    }
}
