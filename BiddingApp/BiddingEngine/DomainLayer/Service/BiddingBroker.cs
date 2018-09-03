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
    using System.Configuration;
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
        /// The maximum mark rating
        /// </summary>
        private static readonly int MaxMarkRating = int.Parse(ConfigurationManager.AppSettings.Get("MaxMarkRating"));

        /// <summary>
        /// The minimum mark rating
        /// </summary>
        private static readonly int MinMarkRating = 1;

        /// <summary>
        /// The minimum rating allowed for bidding
        /// </summary>
        private static int minRatingAllowedForBidding = int.Parse(ConfigurationManager.AppSettings.Get("MinRatingAllowedForBidding"));

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

            this.tablesProvider = tablesProvider;

            this.currencyConverter = new CurrencyConverter(tablesProvider);
             
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
        public Person RegisterPerson(Person person)
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
                    return person;
                }
            }
            catch (Exception e)
            {
                Log.Info("RegisterPerson: " + e.Message);
                throw e;
            }

            //// at this point person doesn't exist into db. 

            try
            { 
                //// the actual insert
                personTable.InsertPerson(person);
                person = personTable.FetchPersonByPhone(person.Phone); //// in order to update Id

                offeror = new PersonOfferor() { Person = person };
                bidder = new PersonBidder() { Person = person };

                personOfferorTable.InsertPersonOfferor(person.IdPerson, offeror);
                personBidderTable.InsertPersonBidder(person.IdPerson, bidder);

                Log.Info("RegisterPerson: " + person.Name + " person id =" + person.IdPerson + " inserted with success.");
            }
            catch (Exception e)
            {
                Log.Info("RegisterPerson: failed to do roles for person.");
                throw e;
            }

            return person;
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
        public Auction RegisterAuction(Person person, Auction auction)
        {
            IPersonOfferorTable personOfferorTable = this.tablesProvider.GetPersonOfferorTable();
            IProductTable productTable = this.tablesProvider.GetProductTable();
            IAuctionTable auctionTable = this.tablesProvider.GetAuctionTable();

            PersonOfferor offeror = personOfferorTable.FetchPersonOfferorByPerson(person);
            offeror.Person = person;
            Currency currency = auction.Currency;
            Category category = auction.Product.Category;

            try
            {
                auction.PersonOfferor = offeror ?? throw new Exception("BAD OFFEROR");

                auction.ValidateObject();

                auction.Currency.ValidateObject();
                auction.Product.ValidateObject();

                if (auction.Currency.IdCurrency == 0)
                {
                    throw new Exception("Invalid currency.");
                }

                Product product = productTable.FetchProductByAllAttributes(auction.Product.Category.IdCategory, auction.Product);
                if (product != null)
                {
                    product.Category = category;

                    Auction fetched = auctionTable.FetchAuctionByIds(offeror.IdOfferor, product.IdProduct);

                    if (fetched.IdAuction != 0)
                    {
                        fetched.PersonOfferor = offeror;
                        fetched.Product = product;
                        fetched.Currency = currency;

                        return fetched;
                        ////throw new Exception("Auction is already registered");
                    }
                }  
            }
            catch (Exception e)
            {
                throw e;
            }
             
            List<Auction> offerorAuctions = auctionTable.FetchOfferorAuctions(offeror); 
            List<Product> existingProducts = productTable.FetchAllProducts();

            bool canPost = CanAuctionBePostedCheck.DoCheck(offeror, auction, offerorAuctions, existingProducts);

            if (!canPost)
            {
                throw new Exception("CanAuctionBePostedCheck failed!");
            } 
             
            productTable.InsertProduct(category.IdCategory, auction.Product); 

            Product selectedProduct = productTable.FetchProductByAllAttributes(category.IdCategory, auction.Product);
            selectedProduct.Category = category;

            auctionTable.InsertAuction(offeror.IdOfferor, selectedProduct.IdProduct, currency.IdCurrency, auction);

            auction = auctionTable.FetchAuctionByIds(offeror.IdOfferor, selectedProduct.IdProduct);
            auction.PersonOfferor = offeror;
            auction.Product = selectedProduct;
            auction.Currency = currency;

            this.auctions.Add(auction);

            AuctionService auctionService = new AuctionService(auction);
            auctionService.StartTimers();

            return auction;
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
                PersonBidder personBidder = personBidderTable.FetchPersonBidderByIdPerson(person.IdPerson);
                bid.PersonBidder = personBidder ?? throw new Exception("no person bidder!");
                personBidder.Person = person;

                Bid highest_bid = this.GetHighestBid(auction);
                if (highest_bid != null)
                {
                    highest_bid.PersonBidder = personBidderTable.FetchPersonByIdBid(highest_bid.IdBid);
                    highest_bid.Currency = auction.Currency;
                    highest_bid.Auction = auction;
                }

                bool isOkToPostBid = CanBidBePostedToActionCheck.DoCheck(personBidder, bid, auction, highest_bid);
                if (!isOkToPostBid)
                {
                    throw new Exception("INVALID BID!");
                }

                bidTable.InsertBid(personBidder.IdBidder, auction.IdAuction, auction.Currency.IdCurrency, bid);

                Log.Info("bid registered!");
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        /// <summary>
        /// Posts the mark.
        /// </summary>
        /// <param name="fromPerson">From person.</param>
        /// <param name="toPerson">To person.</param>
        /// <param name="mark">The mark.</param>
        /// <exception cref="System.Exception">A PERSON IS NOT REGISTERED!</exception>
        public void PostMark(Person fromPerson, Person toPerson, int mark)
        {
            IPersonOfferorTable personOfferorTable = this.tablesProvider.GetPersonOfferorTable();
            IPersonMarkTable personMarkTable = this.tablesProvider.GetPersonMarkTable();

            fromPerson.ValidateObject();
            toPerson.ValidateObject();
           
            if (fromPerson.IdPerson == 0 || toPerson.IdPerson == 0)
            {
                throw new Exception("A PERSON IS NOT REGISTERED!");
            }

            PersonOfferor offeror = personOfferorTable.FetchPersonOfferorByPerson(toPerson);
            
            if (mark > MaxMarkRating || mark < MinMarkRating)
            {
                throw new Exception("BadRating");
            }

            PersonOfferorMark markObj = new PersonOfferorMark() { DateOccur = DateTime.Now, Mark = mark, Receiver = offeror, Sender = fromPerson };

            personMarkTable.InsertPersonMark(markObj);

            Log.Info("mark registered!");

            PersonOfferorService offerorService = new PersonOfferorService(offeror);

            List<PersonOfferorMark> marks = personMarkTable.FetchPersonOfferorMarks(offeror);

            offerorService.UpdateRatingBasedOnMarks(marks);

            if (offerorService.Rating < minRatingAllowedForBidding)
            {
                offeror.LastBannedDate = DateTime.Now;
                offerorService.UpdateIsBanned();
                personOfferorTable.UpdatePersonOfferor(offeror);
            }
        }

        /// <summary>
        /// Gets the person by phone.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns>the found person</returns>
        public Person GetPersonByPhone(string phone)
        {
            IPersonTable personTable = this.tablesProvider.GetPersonTable();

            return personTable.FetchPersonByPhone(phone);
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

            throw new Exception("not found");
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
        /// <param name="person">The person.</param>
        /// <param name="auction">The auction.</param>
        public void EndAuction(Person person, Auction auction)
        {
            IAuctionTable auctionTable = this.tablesProvider.GetAuctionTable();
            IPersonOfferorTable personOfferorTable = this.tablesProvider.GetPersonOfferorTable();

            try
            {
                PersonOfferor offeror = personOfferorTable.FetchPersonOfferorByPerson(person);
                AuctionService auctionService = new AuctionService(auction);

                auctionService.EndAuction(offeror);

                auctionTable.UpdateAuction(auctionService.Auction);
                Log.Info("auction ended!");
            }
            catch (Exception e)
            { 
                Log.Info("EndAuction :" + e.Message);
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

                Log.Info("auctions loaded!");
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
                Log.Info("UpdateCategories succeed!");
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
            Log.Info("UpdateCurrencies succeed!");
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
