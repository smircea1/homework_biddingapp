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
    using BiddingApp.BiddingEngine.DomainLayer.Service.Checks;
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
            this.LoadAuctions();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>this instance.</returns>
        public static BiddingBroker GetInstance()
        {
            if (BiddingBroker.instance == null)
            {
                BiddingBroker.instance = new BiddingBroker();
            }

            return BiddingBroker.instance;
        }

        /// <summary>
        /// Registers the person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>true if it succeeds</returns>
        /// <exception cref="System.Exception">Person is already registered!</exception>
        public bool RegisterPerson(Person person)
        {
            try
            {
                person.ValidateObject();
                if (person.Id != 0)
                {
                    throw new Exception("Person is already registered!");
                }
            }
            catch (Exception e)
            {
                Log.Info("RegisterPerson: " + e.Message);
                return false;
            }

            PersonOfferor offeror = new PersonOfferor() { Person = person };

            domainDataStorage.PersonTable.InsertPerson(person);
             
            Log.Info("RegisterPerson: " + person.Name + " person id =" + person.Id + " inserted with success.");

            return true;
        }

        /// <summary>
        /// Registers the auction.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="auction">The auction.</param>
        /// <returns>
        /// False if the register auction has failed.
        /// </returns>
        public bool RegisterAuction(Person person, Auction auction)
        {
            try
            {
                if (person.Id == 0)
                {
                    throw new Exception("Person is not registered!");
                }

                auction.ValidateObject();
            } 
            catch (Exception e)
            {
                Log.Info(e.Message);
                return false;
            }

            PersonOfferor offeror = domainDataStorage.PersonOfferorTable.FetchPersonOfferorByPerson(person);

            bool canPost = CanAuctionBePostedCheck.DoCheck(offeror, auction);

            if (!canPost)
            {
                return false;
            }

            domainDataStorage.AuctionTable.InsertAuction(auction);
            this.auctions.Add(auction);

            AuctionService auctionService = new AuctionService(auction);
            auctionService.StartTimers();

            return true;
        }

        /// <summary>
        /// Registers the bid.
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <param name="auction">The auction.</param>
        /// <returns>
        /// false if the bid registration had failed.
        /// </returns>
        public bool RegisterBid(Bid bid, Auction auction)
        {
            bool isOkToPostBid = CanBidBePostedToActionCheck.DoCheck(bid, auction);

            if (!isOkToPostBid)
            {
                //// throw
                return false;
            }

            domainDataStorage.BidTable.Insert(bid);

            //// MAYBE NOTICE CURRENT BIDDER HAS CHANGED

            return true;
        }

        /// <summary>
        /// Ends the auction.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <param name="auction">The auction.</param>
        /// <returns>
        /// False if the end auction had failed.
        /// </returns>
        public bool EndAuction(PersonOfferor offeror, Auction auction)
        {
            AuctionService auctionService = new AuctionService(auction);
            return auctionService.EndAuction(offeror);
        }

        /// <summary>
        /// Loads the auctions.
        /// </summary>
        private void LoadAuctions()
        {
            List<Auction> auctions = domainDataStorage.AuctionTable.FetchAllAuctions();
        }
    }
}
