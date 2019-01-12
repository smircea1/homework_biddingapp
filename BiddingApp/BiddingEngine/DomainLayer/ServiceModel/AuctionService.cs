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
    using BiddingApp.BiddingEngine.DomainLayer.Service.Checks;

    /// <summary>
    /// Wraps an auction in order to be used by the broker
    /// </summary>
    public class AuctionService
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
            try
            {
                auction.ValidateObject(); 
            } 
            catch (Exception e)
            {
                throw e;
            }

            this.Auction = auction;
            this.UpdateStatus();
        }

        /// <summary>
        /// Gets the auction.
        /// </summary>
        /// <value>
        /// The auction.
        /// </value>
        public Auction Auction { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether [had ended].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [had ended]; otherwise, <c>false</c>.
        /// </value>
        public bool HadEnded { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether [had started].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [had started]; otherwise, <c>false</c>.
        /// </value>
        public bool HadStarted { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; internal set; }

        /// <summary>
        /// Ends the auction.
        /// </summary>
        /// <param name="offeror">The offer person.</param> 
        public void EndAuction(PersonOfferor offeror)
        {
            try
            {
                this.Auction.ValidateObject();
                CanOfferorEndAuctionCheck.DoCheck(offeror, this);
            } 
            catch (Exception e)
            {
                throw e;
            }

            this.IsActive = false;
            this.Auction.EndDate = DateTime.Now;
            this.HadEnded = true; 
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        internal void UpdateStatus()
        { 
            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.Auction.EndDate - current;
            TimeSpan untilStart = this.Auction.StartDate - current;

            this.HadStarted = untilStart < TimeSpan.Zero; //// true if current time > start time
            this.HadEnded = untilEnd < TimeSpan.Zero; //// true if current time > end time 

            this.IsActive = this.HadStarted && !this.HadEnded;

            Log.Info("Auction::UpdateStatus: updated!");
        }

        /// <summary>
        /// Setups the timers.
        /// </summary>
        internal void StartTimers()
        {
            Log.Info("Auction::SetupTimers: Timers set begin!");

            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.Auction.EndDate - current;
            TimeSpan untilStart = this.Auction.StartDate - current;

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
            this.UpdateStatus();
            Log.Info("AUCTION ENDED!");
        }

        /// <summary>
        /// Called when [auction started].
        /// </summary>
        private void OnAuctionStarted()
        {
            this.UpdateStatus();
            Log.Info("AUCTION STARTED!");
        }
    }
}
