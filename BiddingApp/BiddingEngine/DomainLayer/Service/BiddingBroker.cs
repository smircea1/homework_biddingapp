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
        /// The auctions
        /// </summary>
        private List<Auction> auctions = new List<Auction>();

        /// <summary>
        /// The tables provider
        /// </summary>
        private ITablesProvider tablesProvider;

        /// <summary>
        /// The currency converter
        /// </summary>
        private CurrencyConverter currencyConverter;

        /// <summary>
        /// The available categories
        /// </summary>
        private List<Category> availableCategories;

        /// <summary>
        /// The available currencies
        /// </summary>
        private List<Currency> availableCurrencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="BiddingBroker"/> class.
        /// </summary>
        /// <param name="tablesProvider">The tables provider.</param>
        public BiddingBroker(ITablesProvider tablesProvider)
        {
            this.auctions = new List<Auction>();

            this.currencyConverter = new CurrencyConverter(tablesProvider);

            this.tablesProvider = tablesProvider;

            this.UpdateCategories();
            this.UpdateCurrencies();
            this.LoadAuctions();
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

            IPersonTable personTable = this.tablesProvider.GetPersonTable();
            IPersonBidderTable personBidderTable = this.tablesProvider.GetPersonBidderTable();
            IPersonOfferorTable personOfferorTable = this.tablesProvider.GetPersonOfferorTable();

            try
            { 
                if (person.IdPerson != 0)
                {
                    throw new Exception("Person is already registered!");
                }

                person.ValidateObject();

                Person exists = personTable.FetchPersonByPhone(person.Phone);
                 
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
            personTable.InsertPerson(person);
            person = personTable.FetchPersonByPhone(person.Phone); //// in order to update Id
             
            offeror = new PersonOfferor() { Person = person };
            bidder = new PersonBidder() { Person = person };

            try
            {
                personOfferorTable.InsertPersonOfferor(person.IdPerson, offeror);
                personBidderTable.InsertPersonBidder(person.IdPerson, bidder);

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
            IPersonOfferorTable personOfferorTable = this.tablesProvider.GetPersonOfferorTable();
            IProductTable productTable = this.tablesProvider.GetProductTable();
            IAuctionTable auctionTable = this.tablesProvider.GetAuctionTable();

            PersonOfferor offeror = personOfferorTable.FetchPersonOfferorByPerson(person);
             
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
             
            List<Auction> offerorAuctions = auctionTable.FetchOfferorAuctions(offeror); 
            List<Product> existingProducts = productTable.FetchAllProducts();

            bool canPost = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuctions, existingProducts);

            if (!canPost)
            {
                return false;
            }

            Currency currency = auction.Currency;

            productTable.InsertProduct(auction.Product);
            Product selectedProduct = null;

            auctionTable.InsertAuction(offeror.IdOfferor, selectedProduct.IdProduct, currency.IdCurrency, auction);
            this.auctions.Add(auction);

            AuctionService auctionService = new AuctionService(auction);
            auctionService.StartTimers();

            return true;
        }

        /// <summary>
        /// Registers the bid.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="bid">The bid.</param>
        /// <param name="auction">The auction.</param>
        /// <exception cref="System.Exception">INVALID BID!</exception>
        public void RegisterBid(Person person, Bid bid, Auction auction)
        {
            IPersonBidderTable personBidderTable = this.tablesProvider.GetPersonBidderTable();
            IBidTable bidTable = this.tablesProvider.GetBidTable();

            try
            {
                PersonBidder personBidder = personBidderTable.FetchPersonBidderByPerson(person);

                bid.PersonBidder = personBidder;

                Bid highest_bid = this.GetHighestBid(auction);

                bool isOkToPostBid = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highest_bid);
                if (!isOkToPostBid)
                {
                    throw new Exception("INVALID BID!");
                }

                bidTable.InsertBid(personBidder.Id, auction.IdAuction, auction.Currency.IdCurrency, bid);
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        /// <summary>
        /// Gets the available categories.
        /// </summary>
        /// <returns>All available categories.</returns>
        public List<Category> GetAvailableCategories()
        {
            ICategoryTable categoryTable = this.tablesProvider.GetCategoryTable();
            List<Category> categories = categoryTable.FetchAllCategories(); 
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
        /// <returns>
        /// the currency found or null
        /// </returns>
        /// <exception cref="System.Exception">Currency not found!</exception>
        public Currency GetCurrencyByName(string name)
        { 
            foreach (Currency currency in this.availableCurrencies)
            {
                if (currency.Name.Equals(name))
                {
                    return currency;
                }
            }

            throw new Exception("Currency not found!");
        }

        /// <summary>
        /// Gets the currency converter.
        /// </summary>
        /// <returns>This currency converter</returns>
        public CurrencyConverter GetCurrencyConverter()
        {
            return this.currencyConverter;
        }

        /// <summary>
        /// Ends the auction.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <param name="auction">The auction.</param>
        public void EndAuction(PersonOfferor offeror, Auction auction)
        {
            IAuctionTable auctionTable = this.tablesProvider.GetAuctionTable();
            try
            {
                AuctionService auctionService = new AuctionService(auction);

                auctionService.EndAuction(offeror);

                auctionTable.UpdateAuction(auctionService.Auction); 
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        /// <summary>
        /// Loads the auctions.
        /// </summary>
        private void LoadAuctions()
        {
            IAuctionTable auctionTable = this.tablesProvider.GetAuctionTable();
            try
            {
                List<Auction> auctions = auctionTable.FetchAllAuctions();
                if (auctions != null)
                {
                    this.auctions = auctions;
                }
            }
            catch (Exception e)
            {
                Log.Info(e);
            }
        }

        /// <summary>
        /// Updates the categories.
        /// </summary>
        private void UpdateCategories()
        {
            try
            { 
                CategoriesUpdater.UpdateCategories(this.tablesProvider);
                this.availableCategories = CategoriesUpdater.GetAllAvailableCategories();
            } 
            catch (Exception e)
            {
                Log.Info("UpdateCategories: " + e.Message);
            } 
        }

        /// <summary>
        /// Updates the currencies.
        /// </summary>
        private void UpdateCurrencies()
        {
            this.availableCurrencies = this.currencyConverter.AvailableCurrencies;
        }

        /// <summary>
        /// Gets the highest bid.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>
        /// the highest bid if exists else it throws
        /// </returns>
        private Bid GetHighestBid(Auction auction)
        {
            IBidTable bidTable = this.tablesProvider.GetBidTable();
            try
            {
                return bidTable.FetchAuctionHighestBid(auction);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
