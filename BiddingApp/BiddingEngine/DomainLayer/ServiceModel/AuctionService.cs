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
    using System.Threading;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Wraps an auction in order to be used by the broker
    /// </summary>
    internal class AuctionService
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The timer
        /// </summary>
        private System.Threading.Timer endTimer;

        /// <summary>
        /// The start timer
        /// </summary>
        private System.Threading.Timer startTimer;
         
        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionService"/> class.
        /// </summary>
        /// <param name="auction">The auction.</param>
        public AuctionService(Auction auction)
        {
            this.Auction = auction;
            this.UpdateStatus();
            this.HistoryBids = new List<Bid>(); 
        }

        /// <summary>
        /// Gets or sets the bids history.
        /// </summary>
        /// <value>
        /// The bids history.
        /// </value>
        public List<Bid> HistoryBids { get; internal set; }

        /// <summary>
        /// Gets or sets the auction.
        /// </summary>
        /// <value>
        /// The auction.
        /// </value>
        public Auction Auction { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is ended.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ended; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnded { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen { get; internal set; }

        /// <summary>
        /// Determines whether [is bid eligible] [the specified bid].
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>
        ///   <c>true</c> if [is bid eligible] [the specified bid]; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsBidEligible(Bid bid)
        { 
            ////Bid current_bid = this.Auction.CurrentBid;
            ////if (current_bid == null)
            ////{
            ////    //// If there is no bid, then bid over the starting price
            ////    current_bid = new Bid(this.Auction.I, this.Auction.StartingMoney);
            ////}

            //////// The same person cannot bid its own bid.
            ////if (current_bid.IdBidder == bid.IdBidder)
            ////{
            ////    return false;
            ////}

            //////// The bid should be already exchanged to auction's currency
            ////if (!bid.Offered.Currency.Name.Equals(this.Auction.GetCurrency().Name))
            ////{
            ////    return false;
            ////}

            ////Money current_bid_money = current_bid.Offered;

            //////// Max current price + 50% * current price
            ////double max_new_bid_value = current_bid_money.Value + (current_bid_money.Value / 2);

            //////// Price should be bigger than existent one, but not bigger than 50% + current price
            ////bool price_ok = bid.Offered.Value > current_bid_money.Value && bid.Offered.Value < max_new_bid_value;
            bool price_ok = false;
            return price_ok;
        }


        /// <summary>
        /// Updates the status.
        /// </summary>
        internal void UpdateStatus()
        {
            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.Auction.EndDate.TimeOfDay - current.TimeOfDay;
            TimeSpan untilStart = this.Auction.StartDate.TimeOfDay - current.TimeOfDay;

            this.IsOpen = untilStart < TimeSpan.Zero; //// true if current time > start time
            this.IsEnded = untilEnd < TimeSpan.Zero; //// true if current time > end time 

            Log.Info("Auction::UpdateStatus: updated!");
        }

        /// <summary>
        /// Setups the timers.
        /// </summary>
        internal void SetupTimers()
        {
            Log.Info("Auction::SetupTimers: Timers set begin!");

            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.Auction.EndDate.TimeOfDay - current.TimeOfDay;
            TimeSpan untilStart = this.Auction.StartDate.TimeOfDay - current.TimeOfDay;

            this.UpdateStatus();

            if (!this.IsOpen)
            {
                this.startTimer = new System.Threading.Timer(
                x => { this.OnAuctionStarted(); }, null, untilStart, Timeout.InfiniteTimeSpan);

                Log.Info("Auction::SetupTimers: Start timer had started.");
            }

            if (!this.IsEnded)
            {
                this.endTimer = new System.Threading.Timer(
                x => { this.OnAuctionEnded(); }, null, untilEnd, Timeout.InfiniteTimeSpan);

                Log.Info("Auction::SetupTimers: End timer had started.");
            }

            Log.Info("Auction::SetupTimers: Timers set ended!");
        }

        /// <summary>
        /// Called when [auction ended].
        /// </summary>
        private void OnAuctionEnded()
        {
            this.IsEnded = true;
            Log.Info("AUCTION ENDED!");
        }

        /// <summary>
        /// Called when [auction started].
        /// </summary>
        private void OnAuctionStarted()
        {
            this.IsOpen = true;
            Log.Info("AUCTION STARTED!");
        } 
    }
}
