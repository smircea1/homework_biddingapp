//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Transilvania University of Brasov"> 
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
    using System.Threading.Tasks;

    /// <summary>
    /// The person who posts a bid or who bidds
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The auctions in progress
        /// </summary>
        private List<Auction> auctionsInProgress = new List<Auction>();

        /// <summary>
        /// The auctions finished
        /// </summary>
        private List<Auction> auctionsFinished = new List<Auction>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double Rating { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this instance is banned.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is banned; otherwise, <c>false</c>.
        /// </value>
        public bool IsBanned { get; internal set; }

        /// <summary>
        /// Loads the person.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>The loaded Person</returns>
        public static Person LoadPerson(string personId)
        {
            //// you should load from DB
            return new Person();
        }

        /// <summary>
        /// Gets the in progress auctions.
        /// </summary>
        /// <returns>Returns the in progress auctions list</returns>
        public List<Auction> GetInProgressAuctions()
        {
            return this.auctionsInProgress;
        }

        /// <summary>
        /// Gets the finished auctions.
        /// </summary>
        /// <returns>Returns the finished auctions list</returns>
        public List<Auction> GetFinishedAuctions()
        {
            return this.auctionsFinished;
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>true if they are equal.</returns>
        public bool Equals(Person other)
        {
            return this.Id.Equals(other.Id);
        }

        /// <summary>
        /// Counts the active auctions in category.
        /// </summary>
        /// <param name="categorySeachingFor">The category seaching for.</param>
        /// <returns>The number of the in progress auctions in category.</returns>
        public int CountActiveAuctionsInCategory(Category categorySeachingFor)
        {
            int counter = 0;

            foreach (Auction auction in this.auctionsInProgress)
            {
                foreach (Category category in auction.Product.Categories)
                {
                    if (category.Name.Equals(categorySeachingFor.Name))
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Builds a Person
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The pending person which would be built
            /// </summary>
            private Person pending;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            public Builder()
            {
                this.pending = new Person();
            }

            /// <summary>
            /// Sets the name of the new person.
            /// </summary>
            /// <param name="name">The name.</param>
            public void SetName(string name)
            {
                this.pending.Name = name;
            }

            /// <summary>
            /// Sets the identifier.
            /// </summary>
            /// <param name="id">The identifier.</param>
            public void SetId(string id)
            {
                this.pending.Id = id;
            }

            /// <summary>
            /// Sets the is banned.
            /// </summary>
            /// <param name="isBanned">if set to <c>true</c> [is banned].</param>
            public void SetIsBanned(bool isBanned)
            {
                this.pending.IsBanned = isBanned;
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>The just created person.</returns>
            public Person Build()
            {
                if (this.pending.Name.Length == 0)
                {
                    return null;
                }

                if (this.pending.Id.Length == 0)
                {
                    return null;
                }

                return this.pending;
            }
        }
    }
}
