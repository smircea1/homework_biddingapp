//-----------------------------------------------------------------------
// <copyright file="Auction.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An auction
    /// </summary>
    public class Auction
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
        /// The bids history
        /// </summary>
        private List<Bid> bidsHistory = new List<Bid>();

        /// <summary>
        /// Prevents a default instance of the <see cref="Auction"/> class from being created.
        /// </summary>
        private Auction()
        {
            this.IsOpen = false;
            this.IsEnded = true;
        }

        /// <summary>
        /// Gets the auction owner.
        /// </summary>
        /// <value>
        /// The auction owner.
        /// </value>
        public Person ProductOwner { get; internal set; }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public Product Product { get; internal set; }

        /// <summary>
        /// Gets the starting money.
        /// </summary>
        /// <value>
        /// The starting money.
        /// </value>
        public Money StartingMoney { get; internal set; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; internal set; }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance is ended.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ended; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnded { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen { get; internal set; }

        /// <summary>
        /// Gets the current bid.
        /// </summary>
        /// <value>
        /// The current bid.
        /// </value>
        public Bid CurrentBid { get; internal set; }

        /// <summary>
        /// Gets the bids history.
        /// </summary>
        /// <returns>Returns the bid historic</returns>
        public List<Bid> GetBidsHistory()
        {
            return this.bidsHistory;
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns>The auctions's currency</returns>
        public Currency GetCurrency()
        {
            return this.StartingMoney.Currency;
        }

        /// <summary>
        /// Determines whether [is bid eligible] [the specified bid].
        /// </summary>
        /// <param name="bid">The bid.</param>
        /// <returns>
        ///   <c>true</c> if [is bid eligible] [the specified bid]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsBidEligible(Bid bid)
        {
            Bid current_bid = this.CurrentBid;
            if (current_bid == null)
            {
                current_bid = new Bid(this.ProductOwner, this.StartingMoney);
            }

            //// The same person cannot bid its own bid.
            if (current_bid.Person.Equals(bid.Person))
            {
                return false;
            }

            //// The bid should be already exchanged to auction's currency
            if (!bid.Offered.Currency.Name.Equals(this.GetCurrency().Name))
            {
                return false;
            }

            Money current_bid_money = current_bid.Offered;

            //// Max current price + 50% * current price
            double max_new_bid_value = current_bid_money.Value + (current_bid_money.Value / 2);

            //// Price should be bigger than existent one, but not bigger than 50% + current price
            bool price_ok = bid.Offered.Value > current_bid_money.Value && bid.Offered.Value < max_new_bid_value;

            return price_ok;
        }

        /// <summary>
        /// Setups the timers.
        /// </summary>
        private void SetupTimers()
        {
            DateTime current = DateTime.Now;
            TimeSpan untilEnd = this.EndDate.TimeOfDay - current.TimeOfDay;
            TimeSpan untilStart = this.StartDate.TimeOfDay - current.TimeOfDay;

            if (untilEnd < TimeSpan.Zero)
            {
                //// time already passed
                this.IsEnded = true; 
            } 
            else
            {
                this.IsEnded = false;

                this.endTimer = new System.Threading.Timer(
                x => { this.OnAuctionEnded(); }, null, untilEnd, Timeout.InfiniteTimeSpan);

                Log.Info("Auction::SetupTimers: End timer had started.");
            }

            if (untilStart < TimeSpan.Zero)
            {
                //// time already passed
                this.IsOpen = true; 
            } 
            else
            {
                this.IsOpen = false;

                this.startTimer = new System.Threading.Timer(
                x => { this.OnAuctionStarted(); }, null, untilStart, Timeout.InfiniteTimeSpan);

                Log.Info("Auction::SetupTimers: Start timer had started.");
            }
        }

        /// <summary>
        /// Called when [auction ended].
        /// </summary>
        private void OnAuctionEnded()
        {
            this.IsEnded = true;
        }

        /// <summary>
        /// Called when [auction started].
        /// </summary>
        private void OnAuctionStarted()
        {
            this.IsOpen = true;
        }

        /// <summary>
        /// The builder of an auction.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The pending
            /// </summary>
            private Auction pending;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            public Builder()
            {
                this.pending = new Auction();
            }

            /// <summary>
            /// Sets the owner.
            /// </summary>
            /// <param name="owner">The owner.</param>
            public void SetOwner(Person owner)
            {
                this.pending.ProductOwner = owner;
            }

            /// <summary>
            /// Sets the product.
            /// </summary>
            /// <param name="product">The product.</param>
            public void SetProduct(Product product)
            {
                this.pending.Product = product;
            }

            /// <summary>
            /// Sets the starting money.
            /// </summary>
            /// <param name="price">The price.</param>
            public void SetStartingMoney(Money price)
            {
                this.pending.StartingMoney = price;
            }

            /// <summary>
            /// Sets the start date.
            /// </summary>
            /// <param name="start">The start.</param>
            public void SetStartDate(DateTime start)
            {
                this.pending.StartDate = start;
            }

            /// <summary>
            /// Sets the end date.
            /// </summary>
            /// <param name="end">The end.</param>
            public void SetEndDate(DateTime end)
            {
                this.pending.EndDate = end;
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>The just created auction.</returns>
            /// <exception cref="Exception">
            /// you must provide an action owner!
            /// or
            /// you must provide a product to the auction!
            /// or
            /// invalid start/end dates!
            /// or
            /// negative price is not allowed!
            /// </exception>
            public Auction Build()
            {
                if (this.pending.ProductOwner == null)
                {
                    throw new Exception("you must provide an action owner!");
                }

                if (this.pending.Product == null)
                {
                    throw new Exception("you must provide a product to the auction!");
                }

                DateTime dateStart = this.pending.StartDate;
                DateTime dateEnd = this.pending.EndDate;

                if (dateStart == null || dateEnd == null)
                {
                    throw new Exception("dates are not set!");
                }

                if (dateStart.CompareTo(dateEnd) >= 0)
                {
                    // cannot start after end date or if they are the same.
                    throw new Exception("invalid start/end dates!");
                }

                if (this.pending.StartingMoney == null)
                {
                    throw new Exception("no starting price set!");
                }

                if (this.pending.StartingMoney.Value < 0)
                {
                    throw new Exception("negative price is not allowed!");
                }

                this.pending.SetupTimers();

                return this.pending;
            }
        }
    }
}
