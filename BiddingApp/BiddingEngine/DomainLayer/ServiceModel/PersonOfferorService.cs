//-----------------------------------------------------------------------
// <copyright file="AuctionService.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.ServiceModel
{
    using System;
    using System.Collections.Generic;
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
            int counter = 0;

            List<Auction> offerorAuctions = DomainDataStorage.GetInstance().AuctionTable.FetchOfferorAuctions(this.Offeror);
            

            foreach (Auction auction in this.Person.GetInProgressAuctions())
            {
                //    foreach (Category category in auction.Product.Categories)
                //    {
                //        if (category.Name.Equals(categorySeachingFor.Name))
                //        {
                //            counter++;
                //        }
                //    }
            }

            return counter;
        }
    }
}
