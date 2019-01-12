//-----------------------------------------------------------------------
// <copyright file="CanAuctionBePostedCheck.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   

namespace BiddingApp.BiddingEngine.DomainLayer.Service.Checks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;

    /// <summary>
    /// this is the check in order to post an auction
    /// </summary>
    public class CanAuctionBePostedCheck
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Does the check.
        /// </summary>
        /// <param name="personOfferor">The person offer.</param>
        /// <param name="auction">The auction.</param>
        /// <param name="offerorAuctions">The offer person auctions.</param>
        /// <param name="allProducts">All products.</param>
        /// <returns>
        /// true if the auction can be posted.
        /// </returns>
        public static bool DoCheck(PersonOfferor personOfferor, Auction auction, List<Auction> offerorAuctions, List<Product> allProducts)
        {  
            PersonOfferorService offerorService = new PersonOfferorService(personOfferor);

            //// if it's banned.
            if (offerorService.IsBanned)
            {
                return false;
            }

            //// can't have more than this.
            bool hasMaxAuctions = offerorService.DidPersonHitMaxListLimit(personOfferor, offerorAuctions);
            if (hasMaxAuctions)
            {
                return false;
            }

            //// can't have more than this in specified category.
            List<Auction> offerorCategoryAuctions = new List<Auction>();
            foreach (Auction listed_auction in offerorAuctions)
            {
                if (listed_auction.Product.Category.Name.Equals(auction.Product.Category.Name))
                {
                    offerorCategoryAuctions.Add(listed_auction);
                }
            }

            bool hasMaxInCategory = offerorService.DidPersonHitMaxCategoryListLimit(personOfferor, auction.Product.Category, offerorCategoryAuctions);
            if (hasMaxInCategory)
            {
                return false;
            }

            AuctionService auctionService = new AuctionService(auction); 

            //// if it's older
            if (DateTime.Now.CompareTo(auction.StartDate) > 0)
            {
                //// it should not be older than 5 min.
                bool olderThanMinutes = (DateTime.Now - auction.StartDate).TotalMinutes > 5;
                if (olderThanMinutes)
                {
                    ////return false;
                }
            }

            bool anySimilarExists = ExistsAnySimilarProductCheck.DoCheck(auction.Product, allProducts);

            //// should not be similar.
            if (anySimilarExists)
            {
                Log.Info(auction.Product.Name + " already exists due to LevensteinDistance!");
                return false;
            }

            return true;
        }
    }
}
