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
    public class PersonOfferorService
    {
        /// <summary>
        /// The default rating
        /// </summary>
        private static int defaultRating = int.Parse(ConfigurationManager.AppSettings.Get("DefaultRating"));

        /// <summary>
        /// The reviews counted for rating
        /// </summary>
        private static int reviewsCountedForRating = int.Parse(ConfigurationManager.AppSettings.Get("ReviewsCountedForRating")); 

        /// <summary>
        /// The banned days for bad rating
        /// </summary>
        private static int bannedDaysForBadRating = int.Parse(ConfigurationManager.AppSettings.Get("BannedDaysForBadRating"));

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
            offeror.ValidateObject();

            this.Offeror = offeror;

            this.UpdateIsBanned();
        }

        /// <summary>
        /// Gets the offeror.
        /// </summary>
        /// <value>
        /// The offeror.
        /// </value>
        public PersonOfferor Offeror { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance is banned.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is banned; otherwise, <c>false</c>.
        /// </value>
        public bool IsBanned { get; internal set; }

        /// <summary>
        /// Gets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double Rating { get; internal set; }

        /// <summary>
        /// Dids the person hit maximum category list limit.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <param name="category">The category.</param>
        /// <param name="auctions">The auctions.</param>
        /// <returns>
        /// true if he did, false either
        /// </returns>
        public bool DidPersonHitMaxCategoryListLimit(PersonOfferor offeror, Category category, List<Auction> auctions)
        { 
            PersonOfferorService personOfferorService = new PersonOfferorService(offeror);

            int counted = personOfferorService.CountActiveAuctionsInCategory(category, auctions);

            int max_in_category = maxInProgressByCategory;

            return counted >= max_in_category;
        }

        /// <summary>
        /// Dids the person hit maximum list limit.
        /// </summary>
        /// <param name="offeror">The offeror.</param>
        /// <param name="auctions">The auctions.</param>
        /// <returns>
        /// true if he did, false either
        /// </returns>
        public bool DidPersonHitMaxListLimit(PersonOfferor offeror, List<Auction> auctions)
        { 
            PersonOfferorService personOfferorService = new PersonOfferorService(offeror);

            int counted = personOfferorService.CountAllActiveAuctions(auctions);

            int max_in_progress = maxInProgress;

            return counted >= max_in_progress;
        }

        /// <summary>
        /// Updates the rating.
        /// </summary>
        /// <param name="personMarks">The person marks.</param>
        internal void UpdateRatingBasedOnMarks(List<PersonOfferorMark> personMarks)
        { 
            int totalScore = 0;
            int countedMarks = Math.Min(personMarks.Count, reviewsCountedForRating);

            for (int i = 0; i < countedMarks; i++)
            {
                totalScore += personMarks.ElementAt(i).Mark;
            }

            if (countedMarks == 0)
            {
                this.Rating = defaultRating;
            } 
            else
            {
                this.Rating = totalScore / countedMarks;
            } 
        }

        /// <summary>
        /// Updates the is banned.
        /// </summary>
        internal void UpdateIsBanned()
        {
            TimeSpan remainingBanned = this.Offeror.LastBannedDate.TimeOfDay - DateTime.Now.TimeOfDay; 
            this.IsBanned = remainingBanned > TimeSpan.Zero;
        }

        /// <summary>
        /// Does the ban if needed.
        /// </summary>
        /// <param name="categorySeachingFor">The category seaching for.</param>
        /// <param name="offerorAuctions">The offeror auctions.</param>
        /// <returns>
        /// The number of the in progress auctions in category.
        /// </returns>
        private int CountActiveAuctionsInCategory(Category categorySeachingFor, List<Auction> offerorAuctions)
        { 
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
        /// <param name="offerorAuctions">The offeror auctions.</param>
        /// <returns>
        /// count of active auctions.
        /// </returns>
        private int CountAllActiveAuctions(List<Auction> offerorAuctions)
        {
            ////List<Auction> offerorAuctions = DomainDataStorage.GetInstance().AuctionTable.FetchOfferorAuctions(this.Offeror);
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
    }
}
