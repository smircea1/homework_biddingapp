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
    using BiddingApp.BiddingEngine.DomainLayer.Service;
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
        /// The available categories
        /// </summary>
        private List<Category> availableCategories;

        /// <summary>
        /// The available currencies
        /// </summary>
        private List<Currency> availableCurrencies;

        /// <summary>
        /// Prevents a default instance of the <see cref="BiddingBroker"/> class from being created.
        /// </summary>
        private BiddingBroker()
        {
            this.UpdateCategories();
            this.UpdateCurrencies();
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
        /// <returns>
        /// true if it succeeds
        /// </returns>
        /// <exception cref="System.Exception">Person is already registered!</exception>
        public bool RegisterPerson(Person person)
        {
            PersonOfferor offeror;
            PersonBidder bidder;
            try
            { 
                if (person.IdPerson != 0)
                {
                    throw new Exception("Person is already registered!");
                }

                person.ValidateObject();

                Person exists = domainDataStorage.PersonTable.FetchPersonByPhone(person.Phone);
                 
                if (exists != null)
                {
                    person = exists; //// to update the id.
                    return true; //// just login
                }
            }
            catch (Exception e)
            {
                Log.Info("RegisterPerson: " + e.Message);
                return false;
            }

            //// at this point person doesn't exist into db. 

            //// the actual insert
            domainDataStorage.PersonTable.InsertPerson(person);
            person = domainDataStorage.PersonTable.FetchPersonByPhone(person.Phone); //// in order to update Id
             
            offeror = new PersonOfferor() { Person = person };
            bidder = new PersonBidder() { Person = person };

            try
            {
                domainDataStorage.PersonOfferorTable.InsertPersonOfferor(person.IdPerson, offeror);
                domainDataStorage.PersonBidderTable.InsertPersonBidder(person.IdPerson, bidder);

                Log.Info("RegisterPerson: " + person.Name + " person id =" + person.IdPerson + " inserted with success.");
            }
            catch (Exception e)
            {
                Log.Info("RegisterPerson: failed to do roles for person.");
                return false;
            }
             
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
        /// <exception cref="System.Exception">Person is not registered!</exception>
        public bool RegisterAuction(Person person, Auction auction)
        {
            PersonOfferor offeror = domainDataStorage.PersonOfferorTable.FetchPersonOfferorByPerson(person);
             
            try
            {
                auction.PersonOfferor = offeror ?? throw new Exception("BAD OFFEROR");

                auction.ValidateObject();

                if (auction.IdAuction != 0)
                {
                    throw new Exception("Auction is already registered");
                } 

                if (auction.Currency.IdCurrency == 0)
                {
                    throw new Exception("Invalid currency.");
                }
            }
            catch (Exception e)
            {
                return false;
            } 

            bool canPost = CanAuctionBePostedCheck.DoCheck(offeror, auction);

            if (!canPost)
            {
                return false;
            }

            Currency currency = auction.Currency;
             
            domainDataStorage.ProductTable.InsertProduct(auction.Product);
            Product selectedProduct = null;

            domainDataStorage.AuctionTable.InsertAuction(offeror.IdOfferor, selectedProduct.IdProduct, currency.IdCurrency, auction);
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
        /// Gets the available categories.
        /// </summary>
        /// <returns>All available categories.</returns>
        public List<Category> GetAvailableCategories()
        {
            List<Category> categories = domainDataStorage.CategoryTable.FetchAllCategories(); 
            return categories;
        }

        /// <summary>
        /// Gets the name of the category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the found category or null</returns>
        public Category GetCategoryByName(string name)
        {
            foreach (Category category in this.availableCategories)
            {
                if (category.Name.Equals(name))
                {
                    return category;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the name of the currency by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the currency found or null</returns>
        public Currency GetCurrencyByName(string name)
        { 
            return null;
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
         
        /// <summary>
        /// Updates the categories.
        /// </summary>
        private void UpdateCategories()
        {
            try
            {
                CategoriesUpdater.UpdateCategories();
            } 
            catch (Exception e)
            {
                Log.Info("UpdateCategories: " + e.Message);
            }

            this.availableCategories = CategoriesUpdater.GetAllAvailableCategories();
        }

        /// <summary>
        /// Updates the currencies.
        /// </summary>
        private void UpdateCurrencies()
        {
            this.availableCurrencies = CurrencyConverter.GetInstance().AvailableCurrencies;
        }
    }
}
