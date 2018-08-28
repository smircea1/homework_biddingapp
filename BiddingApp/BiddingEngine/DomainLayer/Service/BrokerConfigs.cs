//-----------------------------------------------------------------------
// <copyright file="BrokerConfigs.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------
namespace BiddingApp.BiddingEngine.DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
     
    /// <summary>
    /// This class holds the settings for the bidding broker.
    /// </summary>
    internal class BrokerConfigs
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="BrokerConfigs"/> class from being created.
        /// </summary>
        private BrokerConfigs()
        {
            // DEFAULT CONFIGS
            this.DefaultRating = 100; // 100%
            this.MinRatingAllowedForBidding = 30; // 30%
            this.BannedDaysForBadRating = 3; // 3 days ban for bad Rating.
            this.MaxInProgress = 3;   // max auctions in progress
            this.MaxInProgressByCategory = 1; // only 1 action per category per user.
            this.ReviewsCountedForRating = 3;  // last 3 reviews counts for the rating.
        }
         
        /// <summary>
        /// Gets or sets the maximum in progress auctions for an user.
        /// </summary>
        /// <value>
        /// The maximum in progress.
        /// </value>
        public int MaxInProgress { get; internal set; }

        /// <summary>
        /// Gets or sets the maximum in progress auctions for an user by category.
        /// </summary>
        /// <value>
        /// The maximum in progress by category.
        /// </value>
        public int MaxInProgressByCategory { get; internal set; }

        /// <summary>
        /// Gets or sets the reviews counted for rating.
        /// </summary>
        /// <value>
        /// The reviews counted for rating.
        /// </value>
        public int ReviewsCountedForRating { get; internal set; }

        /// <summary>
        /// Gets or sets the default rating.
        /// </summary>
        /// <value>
        /// The default rating.
        /// </value>
        public int DefaultRating { get; internal set; }

        /// <summary>
        /// Gets or sets the minimum rating allowed for bidding.
        /// </summary>
        /// <value>
        /// The minimum rating allowed for bidding.
        /// </value>
        public int MinRatingAllowedForBidding { get; internal set; }
         
        /// <summary>
        /// Gets or sets the banned days for bad rating.
        /// </summary>
        /// <value>
        /// The banned days for bad rating.
        /// </value>
        public int BannedDaysForBadRating { get; internal set; }

        /// <summary>
        /// Loads the configs.
        /// </summary>
        /// <returns>The loaded configs.</returns>
        public static BrokerConfigs LoadConfigs()
        {
            BrokerConfigs configs = new BrokerConfigs(); 
            //// load from file.  
            return configs;
        }
    }
}
