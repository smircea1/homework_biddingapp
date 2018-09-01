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
    using BiddingApp.BiddingEngine.DomainData;
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
            this.HistoryBids = new List<Bid>(); // not used yet
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
        public bool HadEnded { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool HadStarted { get; internal set; } 

        public bool IsActive { get; internal set; }
         
        /// <summary>
        /// Updates the status.
        /// </summary>
        internal void UpdateStatus()
        {
            this.Auction = DomainDataStorage.GetInstance().AuctionTable.FetchAuctionById(this.Auction.Id);

            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.Auction.EndDate.TimeOfDay - current.TimeOfDay;
            TimeSpan untilStart = this.Auction.StartDate.TimeOfDay - current.TimeOfDay;


            this.HadStarted = untilStart < TimeSpan.Zero; //// true if current time > start time
            this.HadEnded = untilEnd < TimeSpan.Zero; //// true if current time > end time 

            this.IsActive = HadStarted && !HadEnded;

            Log.Info("Auction::UpdateStatus: updated!");
        }

        /// <summary>
        /// Setups the timers.
        /// </summary>
        internal void StartTimers()
        {
            Log.Info("Auction::SetupTimers: Timers set begin!");

            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.Auction.EndDate.TimeOfDay - current.TimeOfDay;
            TimeSpan untilStart = this.Auction.StartDate.TimeOfDay - current.TimeOfDay;

            this.UpdateStatus();

            if (!this.HadStarted)
            {
                this.startTimer = new System.Threading.Timer(
                x => { this.OnAuctionStarted(); }, null, untilStart, Timeout.InfiniteTimeSpan);

                Log.Info("Auction::SetupTimers: Start timer had started.");
            }

            if (!this.HadEnded)
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
            this.HadEnded = true;
            Log.Info("AUCTION ENDED!");
        }

        /// <summary>
        /// Called when [auction started].
        /// </summary>
        private void OnAuctionStarted()
        {
            this.HadStarted = true;
            Log.Info("AUCTION STARTED!");
        } 
    }
}
