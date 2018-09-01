//-----------------------------------------------------------------------
// <copyright file="PersonService.cs" company="Transilvania University of Brasov"> 
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
    /// Wraps a person to be used into service
    /// </summary>
    internal class PersonService
    {
        /// <summary>
        /// The reviews counted for rating
        /// </summary>
        private static int reviewsCountedForRating = int.Parse(ConfigurationManager.AppSettings.Get("ReviewsCountedForRating"));

        /// <summary>
        /// The minimum rating allowed for bidding
        /// </summary>
        private static int minRatingAllowedForBidding = int.Parse(ConfigurationManager.AppSettings.Get("MinRatingAllowedForBidding"));

        /// <summary>
        /// The banned days for bad rating
        /// </summary>
        private static int bannedDaysForBadRating = int.Parse(ConfigurationManager.AppSettings.Get("BannedDaysForBadRating"));

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonService(Person person)
        {
            this.Person = person;
            this.UpdateRating();

            int alreadyBannedDays = 2;

            bool shouldBan = Rating < minRatingAllowedForBidding;
            bool isAlreadyBanned  = bannedDaysForBadRating > alreadyBannedDays;

            if (shouldBan)
            {
                IsBanned = true;
            }
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public Person Person { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is banned.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is banned; otherwise, <c>false</c>.
        /// </value>
        public bool IsBanned { get; internal set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double Rating { get; internal set; }

        /// <summary>
        /// Updates the rating.
        /// </summary>
        private void UpdateRating()
        {
            IPersonMarkTable personMarkTable = DomainDataStorage.GetInstance().PersonMarkTable;

            List<PersonMark> personMarks = personMarkTable.FetchPersonMarks(this.Person);

            int totalScore = 0;
            foreach (PersonMark mark in personMarks)
            {
                totalScore += mark.Mark;
            }

            this.Rating = totalScore / reviewsCountedForRating;
        }
    }
}
