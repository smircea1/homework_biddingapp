//-----------------------------------------------------------------------
// <copyright file="PersonOfferorService.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.ServiceModel
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
     
    /// <summary>
    /// wrapper for offeror
    /// </summary>
    internal class PersonOfferorService
    { 
        /// <summary>
        /// The maximum in progress
        /// </summary>
        private static int maxInProgress = int.Parse(ConfigurationManager.AppSettings.Get("MaxInProgress"));

        /// <summary>
        /// The maximum in progress by category
        /// </summary>
        private static int maxInProgressByCategory = int.Parse(ConfigurationManager.AppSettings.Get("MaxInProgressByCategory"));

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonOfferorService"/> class.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        public PersonOfferorService(PersonOfferor offeror)
        {
            this.Offeror = offeror;
        }

        /// <summary>
        /// Gets or sets the offeror.
        /// </summary>
        /// <value>
        /// The offeror.
        /// </value>
        public PersonOfferor Offeror { get; internal set; }

        /// <summary>
        /// Counts the active auctions in category.
        /// </summary>
        /// <param name="categorySeachingFor">The category seaching for.</param>
        /// <returns>The number of the in progress auctions in category.</returns>
        public int CountActiveAuctionsInCategory(Category categorySeachingFor)
        {
            List<Auction> offerorAuctions = DomainDataStorage.GetInstance().AuctionTable.FetchOfferorAuctionsByCategory(this.Offeror, categorySeachingFor);
            int counted = 0;

            foreach (Auction auction in offerorAuctions)
            {
                AuctionService auctionService = new AuctionService(auction);
                if (!auctionService.HadEnded && auctionService.HadStarted)
                {
                    counted++;
                }
            }

            return counted;
        }

        /// <summary>
        /// Counts all active auctions.
        /// </summary>
        /// <returns>count of active auctions.</returns>
        public int CountAllActiveAuctions()
        {
            List<Auction> offerorAuctions = DomainDataStorage.GetInstance().AuctionTable.FetchOfferorAuctions(this.Offeror);
            int counted = 0;

            foreach (Auction auction in offerorAuctions)
            {
                AuctionService auctionService = new AuctionService(auction);
                if (!auctionService.HadEnded && auctionService.HadStarted)
                {
                    counted++;
                }
            }

            return counted;
        }


        /// <summary>
        /// Dids the person hit maximum category list limit.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <param name="category">The category.</param>
        /// <returns>true if he did, false either</returns>
        public bool DidPersonHitMaxCategoryListLimit(Person person, Category category)
        {
            PersonOfferor offeror = DomainDataStorage.GetInstance().PersonOfferorTable.FetchPersonOfferorByPerson(person);
            PersonOfferorService personOfferorService = new PersonOfferorService(offeror);

            int counted = personOfferorService.CountActiveAuctionsInCategory(category);

            int max_in_category = maxInProgressByCategory;

            return counted >= max_in_category;
        }

        /// <summary>
        /// Dids the person hit maximum list limit.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>true if he did, false either</returns>
        public bool DidPersonHitMaxListLimit(Person person)
        {
            PersonOfferor offeror = DomainDataStorage.GetInstance().PersonOfferorTable.FetchPersonOfferorByPerson(person);
            PersonOfferorService personOfferorService = new PersonOfferorService(offeror);

            int counted = personOfferorService.CountAllActiveAuctions();

            int max_in_progress = maxInProgress;

            return counted >= max_in_progress;
        }
    }
}
